using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        bool winStatus = PlayerPrefs.GetInt("WinStatus") == 1;
        string playerSymbol = PlayerPrefs.GetString("PlayerSymbol");
        string computerSymbol = PlayerPrefs.GetString("ComputerSymbol");

        if (playerSymbol == "draw")
        {
            resultText.text = "It's a draw!";
        }
        // Display the result based on the retrieved values
        else if (winStatus)
        {
            resultText.text = "Player " + playerSymbol + " wins!";
        }
        else
        {
            resultText.text = "Computer " + computerSymbol + " wins!";
        }
    }

    // Update is called once per frame
    void Update() { }
}
