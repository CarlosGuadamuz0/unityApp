using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] options = { "equis", "circulo" };
        GameObject playerController = GameObject.Find("PlayerController");
        playerController.tag = options[UnityEngine.Random.Range(0, 2)];
        options = options.Where(option => option != playerController.tag).ToArray();
        GameObject computerObject = GameObject.Find("ComputerObject");
        computerObject.tag = options[0];
    }

    // Update is called once per frame
    void Update() { }
}
