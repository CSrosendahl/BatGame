using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpotMovement : MonoBehaviour
{
    // Start is called before the first frame update

 
    public float rotateSpeed = 5f;
    
 

    // Update is called once per frame
    void Update()
    {


       
        transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * rotateSpeed, 90) - 45, 0, 0);


    }
}
