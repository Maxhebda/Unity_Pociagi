using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject clickSound;
    bool leftQuitClick = false;
    bool rightQuitClick = false;
    float timeQuitClick = 1.5f;     //1.5sec
    float timeQuitCounter = 0f;
    void Start()
    {
        clickSound = GameObject.FindGameObjectWithTag("ClickSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (leftQuitClick)
        {
            timeQuitCounter -= Time.deltaTime;
            if (timeQuitCounter < 0)
            {
                leftQuitClick = false;
            }
        }
        if (rightQuitClick)
        {
            timeQuitCounter -= Time.deltaTime;
            if (timeQuitCounter < 0)
            {
                rightQuitClick = false;
            }
        }
        if (rightQuitClick && leftQuitClick)
        {
            Application.Quit();
            print("Quit");
        }
    }

    public void SoundPlay_Click()
    {
        clickSound.GetComponent<AudioSource>().Play();  //click
    }
    public void ClickRightQuit()
    {
        SoundPlay_Click();
        rightQuitClick = true;
        timeQuitCounter = timeQuitClick;
    }
    public void ClickLeftQuit()
    {
        SoundPlay_Click();
        leftQuitClick = true;
        timeQuitCounter = timeQuitClick;
    }
}
