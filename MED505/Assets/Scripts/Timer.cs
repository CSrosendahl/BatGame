using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public static Timer instance;
    public float time = 0f;
    public Text timerText;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string minutes = ((int)time / 60).ToString();
        string second = (time % 60).ToString("f0");
        timerText.text = minutes + ":" + second;
    }

    public string getTime()
    {
        string minutes = ((int)(time-15) / 60).ToString();
        string second = ((time-15) % 60).ToString("f0");
        return minutes + " m " + second +" s";
    }

    public void reset()
    {
        time = 0f;
    }
}
