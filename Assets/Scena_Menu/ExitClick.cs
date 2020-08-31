using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitClick : MonoBehaviour
{
    GameObject soundClick;
    void Start()
    {
        soundClick = GameObject.FindWithTag("ClickButtonsMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        soundClick.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
