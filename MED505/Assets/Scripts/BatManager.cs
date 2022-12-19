using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{

    public static BatManager instance;

    private void Awake()
    {
        instance = this;
        states = LaneSwitch.Lane3;
    }

  

    private float startMovementSpeed;
    private bool sprintReady = true;
    private bool canMove = true;
    public bool wasHit = false;

    public Transform batTest;
    public Animator anim;

    public Rigidbody batrb;
    public BoxCollider batHitbox;
    public GameObject SprintParticles;
    public enum LaneSwitch
    {
        Lane1,
        Lane2,
        Lane3,
        Lane4,
        Lane5
    }

    public LaneSwitch states;




    private void Start()
    {
       
       
        GameManager.instance.playerDead = false;
        SprintParticles.SetActive(false);
        startMovementSpeed = GameManager.instance.playerSpeed;
        
        
    }

    private void Update()
    {

        StartCoroutine(WasHitDuration());

       

        if (GameManager.instance.playerDead)
        {
      
            batrb.isKinematic = false;
            batHitbox.isTrigger = false;
            anim.SetTrigger("dead");
            StartCoroutine(WaitForResetGame());
            
        }
        else
        {
            batHitbox.isTrigger = true;
            batrb.isKinematic = true;
            transform.Translate(Vector3.right * GameManager.instance.playerSpeed * Time.deltaTime);
        }

        // Removed SPRINT for now.

        if (Input.GetKeyDown(KeyCode.LeftShift) && sprintReady)
        {
            GameManager.instance.playerSpeed += GameManager.instance.playerSpeed * 8;
            anim.SetTrigger("sprint");
            sprintReady = false;
            canMove = false;
            SprintParticles.SetActive(true);
            StartCoroutine(SprintDuration());
            StartCoroutine(SprintCoolDown());
        }
        IEnumerator SprintDuration()
        {
            yield return new WaitForSeconds(0.2f);
            SprintParticles.SetActive(false);        
            canMove = true;
            GameManager.instance.playerSpeed = startMovementSpeed;
        }

        IEnumerator SprintCoolDown()
        {
            yield return new WaitForSeconds(1);
            sprintReady = true;
        }




        // Strafedistance determines how far your character will move in the given direction
        // Strafespeed determines the speed of the character between strafing.
        // NOTE: Within the if statements there are hardcoded floats. For example, strafeDistance + 0.1f or -strafeDistance - 0.2f
        // These floats are used to avoid calculation errors from the computer, so the character does not get stuck in between lanes. I call them Jiggily room

    
          if (!GameManager.instance.playerDead)
        {         


            if (states == LaneSwitch.Lane2 && batTest.position.z < GameManager.instance.strafeDistance - 0.25f)
            {
                batTest.position += new Vector3(0, 0, GameManager.instance.strafeSpeed * Time.deltaTime);
                
            }
            else if (states == LaneSwitch.Lane2 && batTest.position.z > GameManager.instance.strafeDistance + 0.25f)
            {
                batTest.position += new Vector3(0, 0, -GameManager.instance.strafeSpeed * Time.deltaTime);

            }
            else if (states == LaneSwitch.Lane4 && batTest.position.z < -GameManager.instance.strafeDistance - 0.25f)
            {
                batTest.position += new Vector3(0, 0, GameManager.instance.strafeSpeed * Time.deltaTime);
               
              
            }
            else if (states == LaneSwitch.Lane4 && batTest.position.z > -GameManager.instance.strafeDistance + 0.25f)
            {
                batTest.position += new Vector3(0, 0, -GameManager.instance.strafeSpeed * Time.deltaTime);
                

            }

            else if (states == LaneSwitch.Lane1 && batTest.position.z < GameManager.instance.strafeDistance * 2 - 0.25f)
            {
                batTest.position += new Vector3(0, 0, GameManager.instance.strafeSpeed * Time.deltaTime);
                
            }
            else if (states == LaneSwitch.Lane5 && batTest.position.z > -GameManager.instance.strafeDistance * 2 + 0.25f)
            {
                batTest.position += new Vector3(0, 0, -GameManager.instance.strafeSpeed * Time.deltaTime);
                

            }

            // Middle Left
            else if (states == LaneSwitch.Lane3 && batTest.position.z <= -0.25f)
            {
                batTest.position += new Vector3(0, 0, GameManager.instance.strafeSpeed * Time.deltaTime);
                

            }
            // Middle Right
            else if(states == LaneSwitch.Lane3  && batTest.position.z >= 0.25f)
            {
                batTest.position += new Vector3(0, 0, -GameManager.instance.strafeSpeed * Time.deltaTime);
               

            }
        }




        if (canMove && !GameManager.instance.playerDead)
        {
            // Controls
            switch (states)
            {


                case LaneSwitch.Lane1:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                        Debug.Log("You can't go left");

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        anim.SetTrigger("goRight");
                        states = LaneSwitch.Lane2;

                    }
                    break;
                case LaneSwitch.Lane2:

                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                        anim.SetTrigger("goLeft");
                        states = LaneSwitch.Lane1;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        anim.SetTrigger("goRight");
                        states = LaneSwitch.Lane3;
                        Debug.Log("Go Right");
                    }
                    break;
                case LaneSwitch.Lane3:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                        anim.SetTrigger("goLeft");
                        states = LaneSwitch.Lane2;

                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        anim.SetTrigger("goRight");


                        states = LaneSwitch.Lane4;
                    }
                    break;
                case LaneSwitch.Lane4:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                        anim.SetTrigger("goLeft");
                        states = LaneSwitch.Lane3;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        anim.SetTrigger("goRight");
                        states = LaneSwitch.Lane5;
                        Debug.Log("Go Right");
                    }
                    break;
                case LaneSwitch.Lane5:
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                        anim.SetTrigger("goLeft");
                        states = LaneSwitch.Lane4;

                    }
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {

                        Debug.Log("You can't Go Right");
                    }
                    break;
                default:
                    break;
            }


        }


        IEnumerator WasHitDuration()
        {
           if(wasHit)
            {
                yield return new WaitForSeconds(0.5f);
                wasHit = false;
            }
       
        }
        IEnumerator WaitForResetGame()
        {
            yield return new WaitForSeconds(3f);
            GameManager.instance.ResetGame();

        }
       
    }
}