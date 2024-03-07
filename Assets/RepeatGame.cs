using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatGame : MonoBehaviour
{
    public void clickRepeatGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync("GAMEOVER");
    }
}
