using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    // Start is called before the first frame update

    public static LightCollision instance;
    
    private void Awake()
    {
        instance = this;
    }

    public bool mainCollision;
    public bool areaCollision;
    public Animator anim;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnTriggerEnter(Collider other)
    {

        //if(areaCollision && other.gameObject.tag == "Player")
        //{
        //    AreaCollision();
            

        //}
        if (mainCollision && other.gameObject.tag == "Player")
        {
            MainCollision();
            
        }

    }

    //public void AreaCollision()
    //{
    //    Debug.Log("YOU TAKE NO DAMAGE FROM AREA LIGHT, BUT YOU CANT CONTROL THE BAT: ADD NICK SHADER HERE ");
    //    Movement.instance.wasHit = true; 
    //    anim.SetTrigger("takeDamage");
       
        

    //    if (!Movement.instance.playerDead)
    //    {
    //        AudioSwap.instance.audioSource.clip = AudioManager.instance.hitSound;
    //        AudioSwap.instance.audioSource.Play();
    //    }


    //}
    public void MainCollision()
    {
        Debug.Log("YOU TAKE DAMAGE FROM DIRECT LIGHT AND CANT CONTROL THE BAT, OUCH IT BURNS!: ADD NICK SHADER HERE");
        BatManager.instance.wasHit = true;
        GameManager.instance.PlayerHealth();
        CameraShake.instance.start = true;
        anim.SetTrigger("takeDamage");
        if(!GameManager.instance.playerDead)
        {
            AudioManager.instance.StopAllTracks();
            AudioSwap.instance.audioSource.clip = AudioManager.instance.hitSound;
            AudioSwap.instance.audioSource.Play();
        }
        

    }

 
}
