using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    // Start is called before the first frame update
    public float duration = 1f;
    public AnimationCurve curve;
    public bool start;
    public Transform camStartPos;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shake());

        }

      //  Debug.Log(batscurrentPos.position.x);
    }
    IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strenght = curve.Evaluate(elapsedTime / duration);
            transform.position = camStartPos.position + Random.insideUnitSphere * strenght;
            yield return null;

        }
        transform.position = camStartPos.position;



    }
}
