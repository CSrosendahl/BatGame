using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAndSoundActivator : MonoBehaviour
{
   


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.cars.SetActive(true);
            AudioManager.instance.SwapTrack(AudioManager.instance.bigCitySound);

        }
    }
}
