using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject panel;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }


    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void BackPoem()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        
    }
}
