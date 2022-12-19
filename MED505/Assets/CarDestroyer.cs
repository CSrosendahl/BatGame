using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroyer : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Car")
        {
            
            Debug.Log("Hit car destroyer");
            other.gameObject.transform.position = CarManager.instance.spawner.position;
          
        }
       
    }
}
