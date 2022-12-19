using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public static OutroCollider instance;
    private void Awake()
    {
        instance = this;
    }

    public bool Gameover;

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Gameover = true;
            AudioManager.instance.StopAllTracks();
            GameManager.instance.GameScene.SetActive(false);
            GameManager.instance.HUD.enabled = false;
            GameManager.instance.outtroScene.SetActive(true);
            yield return new WaitForSeconds(15f);
            SceneManager.LoadScene("EndScene");

        }
    }
}
