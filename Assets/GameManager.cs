using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject clickSound;
    GameObject clickOnOff;
    GameObject menuButton;

    bool leftQuitClick = false;
    bool rightQuitClick = false;

    int counterClickMenu = 0;       //5x click to run menu
    float timeMenuCounter = 2f;     // in 5sec
    bool menuClick = false;
    bool menuCounterStart = false;

    float timeQuitClick = 1.5f;     //1.5sec
    float timeQuitCounter = 0f;
    void Start()
    {
        clickSound = GameObject.FindGameObjectWithTag("ClickSound");
        clickOnOff = GameObject.FindGameObjectWithTag("ClickOnOff");
        menuButton = GameObject.FindGameObjectWithTag("MenuButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (menuCounterStart)
        {
            timeMenuCounter -= Time.deltaTime;
        }
        //function menu click
        if (menuClick)
        {
            menuClick = false;
            if (timeMenuCounter > 0)
            {
                counterClickMenu++;
                menuButton.GetComponent<Text>().text = counterClickMenu + "/5";
                if (counterClickMenu > 4)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
        if (menuCounterStart && timeMenuCounter < 0)
        {
                //reset counter
                menuClick = false;
                menuCounterStart = false;
                counterClickMenu = 0;
                menuButton.GetComponent<Text>().text = "MENU";
        }

        // function exit click
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
    public void SoundPlay_OnOff()
    {
        clickOnOff.GetComponent<AudioSource>().Play();  //click
    }
    public void ClickRightQuit()
    {
        SoundPlay_Click();
        rightQuitClick = true;
        timeQuitCounter = timeQuitClick;
    }
    public void ClickMenu()
    {
        menuClick = true;
        timeMenuCounter = 5f;
        menuCounterStart = true;
        SoundPlay_Click();
    }
    public void ClickLeftQuit()
    {
        SoundPlay_Click();
        leftQuitClick = true;
        timeQuitCounter = timeQuitClick;
    }
}
