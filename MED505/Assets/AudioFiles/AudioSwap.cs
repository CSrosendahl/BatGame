using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{

    public static AudioSwap instance;

    private void Awake()
    {
        instance = this;
    }

    public AudioSource audioSource;
    

    bool isPlaying;
  public  bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // AudioManager.instance.SwapTrack(AudioManager.instance.deathSound);

            audioSource.Play();
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.instance.ReturnToDefault();
        }

        if(GameManager.instance.playerDead)
        {
            if (!hasPlayed)
            {
               
                audioSource.clip = AudioManager.instance.deathSound;
                audioSource.Play();
                hasPlayed = true;
            }
            
        }
    }
}
