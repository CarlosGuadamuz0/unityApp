using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openGameScene : MonoBehaviour
{
    public UnityEngine.SceneManagement.Scene openGame;

    public void LoadGameScene()
    {
        // Load the new scene named "Game"
        SceneManager.LoadScene("Login", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
