using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickButtons : MonoBehaviour
{
    public GameObject playerController;
    public GameObject computerController;
    public List<Button> buttonsMatrix;

    // Start is called before the first frame update
    void Start()
    {
        getButtons();
    }

    public void winGameSceneLoad()
    {
        bool winStatusPlayer = CheckWin(buttonsMatrix, playerController.tag);
        bool winStatusComputer = CheckWin(buttonsMatrix, computerController.tag);
        if (retrieveUnselectButtons().Count == 0)
        {
            // Store the values in PlayerPrefs
            PlayerPrefs.SetString("PlayerSymbol", "draw");
            // Load the game scene
            SceneManager.LoadScene("GAMEOVER");
        }
        if (winStatusPlayer || winStatusComputer)
        {
            string playerSymbol = playerController.tag;
            string computerSymbol = computerController.tag;

            // Store the values in PlayerPrefs
            PlayerPrefs.SetInt("WinStatus", winStatusPlayer ? 1 : 0);
            PlayerPrefs.SetString("PlayerSymbol", playerSymbol);
            PlayerPrefs.SetString("ComputerSymbol", computerSymbol);

            // Load the game scene
            SceneManager.LoadScene("GAMEOVER");
        }
        // Before loading the scene, set win status and player's symbol
    }

    bool CheckWin(List<Button> buttons, string player)
    {
        // Check rows
        for (int row = 0; row < 3; row++)
        {
            int startIndex = row * 3;
            if (
                buttons[startIndex].tag == player
                && buttons[startIndex + 1].tag == player
                && buttons[startIndex + 2].tag == player
            )
                return true;
        }

        // Check columns
        for (int col = 0; col < 3; col++)
        {
            if (
                buttons[col].tag == player
                && buttons[col + 3].tag == player
                && buttons[col + 6].tag == player
            )
                return true;
        }

        // Check diagonals
        if (buttons[0].tag == player && buttons[4].tag == player && buttons[8].tag == player)
            return true;
        if (buttons[2].tag == player && buttons[4].tag == player && buttons[6].tag == player)
            return true;

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        winGameSceneLoad();
    }

    public void getButtons()
    {
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 4; j++)
            {
                buttonsMatrix.Add(GameObject.Find("casilla" + i + j).GetComponent<Button>());
            }
        }
        foreach (Button button in buttonsMatrix)
        {
            playerController = GameObject.Find("PlayerController");
            computerController = GameObject.Find("ComputerObject");
            button.onClick.AddListener(onClickGrid);
        }
    }

    public void onClickGrid()
    {
        Button clickedButton =
            UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if (clickedButton != null && clickedButton.tag == "unSelected")
        {
            Sprite loadedSprite = Resources.Load<Sprite>(playerController.tag);
            clickedButton.image.sprite = loadedSprite;
            clickedButton.tag = playerController.tag;
            List<Button> unselectedButtons = retrieveUnselectButtons();
            Debug.Log(unselectedButtons.Count);
            var randomNumber = UnityEngine.Random.Range(0, unselectedButtons.Count);
            Debug.Log("Random Number:" + randomNumber);
            Button unselectedButton = unselectedButtons[randomNumber];
            unselectedButton.image.sprite = Resources.Load<Sprite>(computerController.tag);
            unselectedButton.tag = computerController.tag;
        }
        else
        {
            Debug.LogWarning("No Button component found on the clicked GameObject.");
        }

        // Add your logic here for when a button in the grid is clicked
    }

    private List<Button> retrieveUnselectButtons()
    {
        return buttonsMatrix.FindAll(button => button.CompareTag("unSelected"));
    }
}
