using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semafor : MonoBehaviour
{
    [SerializeField] Sprite[] semaforImage;     //table of image Barrier
    [SerializeField] GameObject SemaphoreLamp;  //ref to lamps Semaphore
    [SerializeField] Sprite[] semaforLamp;      //TABLE OF IMAGE lamps Semaphore

    GameObject gameManager;  //sound Click

    //public sterring
    public bool? barrierIsOpen = true;          //true - open, false - close, null 
    public bool AllowSteringBarrier = true;     //always true

    //task
    public bool openingBarrier = false;         //go open
    public bool closingBarrier = false;         //gp close

    //counter
    byte counterAnimationGate = 0;
    byte counterAnimationLamp = 0;
    float counterTime = 0.3f;
    float counterTimeLamp = 0.2f;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager"); //sound Click
    }

    // Update is called once per frame
    void Update()
    {
        if (openingBarrier && barrierIsOpen == null)
        {
            OpeningAnimations();
        }
        if (closingBarrier && barrierIsOpen == null)
        {
            ClosingAnimations();
        }
        if (barrierIsOpen==false)
        {
            lampBarrierAnimations();
        }
        if (barrierIsOpen!=true)
        {
            lampSemaphoreAnimations();
        }
    }
    public void resetSet()
    {
        counterAnimationGate = 0;
        counterAnimationLamp = 0;
        counterTime = 0.2f;
        counterTimeLamp = 0.3f;
    }
    private void OnMouseDown()
    {
        gameManager.GetComponent<GameManager>().SoundPlay_Click();  //sound click
        if (barrierIsOpen == null)
        {
            return;
        }
        resetSet();

            AllowSteringBarrier = true;         //tymczasowo zawsze zezwalamy.

            if (barrierIsOpen == true)
            {
                barrierIsOpen = null;
                openingBarrier = false;
                closingBarrier = true;
                if (!soundIsPlaying())
                {
                    playSemaphoreSound(true);
                }
            }
            if (barrierIsOpen == false)
            {
                barrierIsOpen = null;
                closingBarrier = false;
                openingBarrier = true;
            }
    }
    void OpeningAnimations()
    {
        counterTime -= Time.deltaTime;

        if (counterTime<0)
        {
            switch(counterAnimationGate)
            {
                case 0:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[2];
                        break;
                    }
                case 1:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[3];
                        break;
                    }
                case 2:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[4];
                        break;
                    }
                case 3:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[5];
                        break;
                    }
                case 4:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[6];
                        break;
                    }
                case 5:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[7];
                        SemaphoreLamp.GetComponent<SpriteRenderer>().sprite = semaforLamp[0];           //turn off semaphore big lamp
                        playSemaphoreSound(false);
                        barrierIsOpen = true;
                        openingBarrier = false;
                        closingBarrier = false;
                        break;
                    }
            }
            counterAnimationGate++;
            counterTime = 0.2f;
        }
    }
    void ClosingAnimations()
    {
        counterTime -= Time.deltaTime;

        if (counterTime < 0)
        {
            switch (counterAnimationGate)
            {
                case 0:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[7];
                        break;
                    }
                case 1:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[6];
                        break;
                    }
                case 2:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[5];
                        break;
                    }
                case 3:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[4];
                        break;
                    }
                case 4:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[3];
                        break;
                    }
                case 5:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[2];
                        barrierIsOpen = false;
                        closingBarrier = false;
                        break;
                    }
            }
            counterAnimationGate++;
            counterTime = 0.2f;
        }
    }
    void lampBarrierAnimations()
    {
        counterTime -= Time.deltaTime;

        if (counterTime < 0)
        {
            switch (counterAnimationGate)
            {
                case 0:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[0];
                        counterAnimationGate = 1;
                        break;
                    }
                case 1:
                    {
                        gameObject.GetComponent<SpriteRenderer>().sprite = semaforImage[1];
                        counterAnimationGate = 0;
                        break;
                    }
                default :
                    {
                        counterAnimationGate = 0;
                        break;
                    }
            }
            counterTime = 0.3f;
        }
    }
    void lampSemaphoreAnimations()
    {
        counterTimeLamp -= Time.deltaTime;

        if (counterTimeLamp < 0)
        {
            switch (counterAnimationLamp)
            {
                case 0:
                    {
                        SemaphoreLamp.GetComponent<SpriteRenderer>().sprite = semaforLamp[1];
                        counterAnimationLamp = 1;
                        break;
                    }
                case 1:
                    {
                        SemaphoreLamp.GetComponent<SpriteRenderer>().sprite = semaforLamp[2];
                        counterAnimationLamp = 0;
                        break;
                    }
                default:
                    {
                        counterAnimationLamp = 0;
                        break;
                    }
            }
            counterTimeLamp = 0.2f;
        }
    }
    bool soundIsPlaying()
    {
        return gameObject.GetComponent<AudioSource>().isPlaying;
    }
    public void playSemaphoreSound(bool play)
    {
        if (play)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}

