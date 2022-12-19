using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static CarManager instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    public GameObject carGO;
    public Transform spawner;
   
    public Transform destroyLocation;

   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
