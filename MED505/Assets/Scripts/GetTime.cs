using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour
{
    public Text endTime;
    // Start is called before the first frame update
    void Start()
    {
        endTime.text = Timer.instance.getTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
