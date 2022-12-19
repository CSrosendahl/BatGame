using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string gameScene;
    public GameObject controls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void controlScene()
    {
        controls.SetActive(true);

    }
    
    public void DoneGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void ReplayGame() 
    {
        SceneManager.LoadScene(gameScene);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(gameScene);
    }
}
