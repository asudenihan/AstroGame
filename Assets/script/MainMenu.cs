using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Game Starts");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadLevel(string levelName)
    {
        Debug.Log("Loading Level " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Debug.Log("Closing the game...");
        Application.Quit();
    }
}