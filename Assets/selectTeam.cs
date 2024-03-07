using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image imagePlayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selectPlayer());
    }

    private IEnumerator selectPlayer()
    {
        List<string> options = new List<string> { "equis", "circulo" };
        GameObject playerController = GameObject.Find("PlayerController");
        for (int i = 0; i < 5; i++)
        {
            playerController.tag = options.Where(tag => tag != playerController.tag).ElementAt(0);
            imagePlayer.sprite = Resources.Load<Sprite>(playerController.tag);
            yield return new WaitForSecondsRealtime(0.5f);
        }

        options = options.Where(option => option != playerController.tag).ToList();
        GameObject computerObject = GameObject.Find("ComputerObject");
        computerObject.tag = options[0];
    }

    // Update is called once per frame
    void Update() { }
}
