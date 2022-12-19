using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        //GameScene.SetActive(false);
        //outtroScene.SetActive(false);
        //introScene.SetActive(true);

    }

    public GameObject GameScene;
    public GameObject introScene;
    public GameObject outtroScene;
    public Canvas HUD;

  

    [HideInInspector] public GameObject cars;
    [HideInInspector] public Transform resetToStart;
    [HideInInspector] public GameObject player;
    [HideInInspector] public GameObject batGameObject;
    public bool playerDead;
    public Image[] imagesToRemove;
    int arrayImage = 0;



    public float playerSpeed;
    public int playerLives;

    public float strafeSpeed;
    public float strafeDistance;


    void Start()
    {
         //StartCoroutine(WaitForIntroScene());
         //HUD.enabled = false;
        GameScene.SetActive(true);

    }

    public void Update()
    {
        if (0 >= playerLives)
        {

            playerDead = true;

        }
    }



    //IEnumerator WaitForIntroScene()
    //{
        
    //    yield return new WaitForSeconds(15f);
    //    introScene.SetActive(false);  
    //    GameScene.SetActive(true);

    //   AudioManager.instance.SwapTrack(AudioManager.instance.suburbSound);

    //    HUD.enabled = true;
    //    Timer.instance.reset();

    //}

    public void ResetGame()
    {
        SceneManager.LoadScene("DeadScene");
    }

    

    public void PlayerHealth()
    {
       

        if(playerLives > 0)
        {
           
            imagesToRemove[arrayImage].enabled = false;
            arrayImage += 1;
            playerLives -= 1;
        } 

        
    }
    
 
}
