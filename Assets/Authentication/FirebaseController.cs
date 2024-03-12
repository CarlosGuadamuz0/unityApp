using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class FirebaseController : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_Text messageText;
    public Button login;

    void Start()
    {
        Button btn = login.GetComponent<Button>();
        btn.onClick.AddListener(CheckCredentials);
    }


    public void CheckCredentials()
    {
        if (emailInput.text == "example@gmail.com" && passwordInput.text == "Test123")
        {
            // Add code to navigate to the Game scene here.
            ShowMessage("Login Correct");
            Debug.Log("Credentials are correct.");
           SceneManager.LoadScene("Game");
        }
        else
        {
            ShowMessage("Incorrect email or password.");
            Debug.Log("Incorrect email or password." + emailInput.text + " " + passwordInput.text);
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.enabled = true;
        StartCoroutine(HideMessageAfterDelay(2));
    }

    IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.enabled = false;
    }
}


