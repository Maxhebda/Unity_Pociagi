using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : MonoBehaviour
{
    GameObject gameManager;
    bool turbineON = true;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gameObject.GetComponent<Animator>().enabled = true;
        turbineON = true;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameManager.GetComponent<GameManager>().SoundPlay_OnOff();  //sound on-off
        if (turbineON)
        {
            turbineON = false;
            gameObject.GetComponent<Animator>().enabled = false;
        }
        else
        {
            turbineON = true;
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
