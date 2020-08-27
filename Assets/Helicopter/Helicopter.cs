using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    //spawn position :
    [SerializeField] Transform rightPos1;        // position spawn balloons
    [SerializeField] Transform rightPos2;
    [SerializeField] Transform leftPos1;
    [SerializeField] Transform leftPos2;
    [SerializeField] Transform leftLand;
    [SerializeField] Transform rightLand;
    [SerializeField] Transform centerLand;
    [SerializeField] Sprite[] HelicopterImages;
    GameObject gameManager; //sound click

    float step;
    float speed = 0.4f;
    float HelicopterPauseCounter = 10f;
    byte helicopterPoint = 0;
    bool helicopterDirection = false;   // false left, true right
    bool helicopterNormal = true;   // normal not landing
    bool helicopterPause = false;   // landing for 10sec
    Vector3 targetPosition, endPosition;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        RandomNewPosition();
        RandomNewSpeed();
        RandomNewPauseCounter();
    }


    void Update()
    {
        step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        if (transform.position == targetPosition)
        {
            if (helicopterPoint==2 && helicopterPause)
            {
                //the helicopter has fly
                playSound(false);
                HelicopterPauseCounter -= Time.deltaTime;
                if (HelicopterPauseCounter < 0)
                {
                    helicopterPause = false;
                }
                return;
            }
            if (helicopterNormal)
            {
                RandomNewPosition();
                RandomNewSpeed();
                RandomNewPauseCounter();
            }
            else
            {
                if (helicopterPoint == 1 && helicopterPause)
                {
                    //the helicopter has landed and has a pause
                    playSound(false);
                    HelicopterPauseCounter -= Time.deltaTime;
                    if (HelicopterPauseCounter < 0)
                    {
                        RandomNewSpeed();
                        playSound(true);
                        helicopterPause = false;
                        RandomNewPauseCounter();
                    }
                }
                else
                {
                    if (helicopterPoint == 0)
                    {
                        targetPosition = centerLand.position;
                        helicopterPoint = 1;
                        helicopterPause = true;
                    }
                    else
                    {
                        if (helicopterPoint == 1)
                        {
                            if (helicopterDirection)
                            {
                                targetPosition = rightLand.position;
                            }
                            else
                            {
                                targetPosition = leftLand.position;
                            }
                            helicopterPoint = 2;
                        }
                        else
                        {
                            targetPosition = endPosition;
                            helicopterNormal = true;
                            helicopterPause = true;
                        }
                    }
                }
            }
            
        }
    }
    void RandomNewPosition()
    {
        //random image
        gameObject.GetComponent<SpriteRenderer>().sprite = HelicopterImages[Random.Range(0,HelicopterImages.Length)];

        //random if helicopter must landing
        helicopterNormal = (byte)(Random.Range(0, 4)) > 1 ? true : false;

        //random left or right
        helicopterDirection = Random.Range(0, 2) == 0 ? true : false;

        helicopterPoint = 0;
        if (helicopterDirection)      // go right;
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            endPosition = new Vector3(rightPos1.position.x, Random.Range(rightPos1.position.y, rightPos2.position.y), transform.position.z);
            transform.position = new Vector3(leftPos1.position.x, Random.Range(leftPos1.position.y, leftPos2.position.y), transform.position.z);
            if (helicopterNormal)
            {
                helicopterPoint = 2;
                targetPosition = endPosition;
            }
            else
            {
                targetPosition = leftLand.position;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            endPosition = new Vector3(Random.Range(leftPos1.position.x, leftPos2.position.x), Random.Range(leftPos1.position.y, leftPos2.position.y), transform.position.z);
            transform.position = new Vector3(Random.Range(rightPos1.position.x, rightPos2.position.x), Random.Range(rightPos1.position.y, rightPos2.position.y), transform.position.z);
            if (helicopterNormal)
            {
                helicopterPoint = 2;
                targetPosition = endPosition;
            }
            else
            {
                targetPosition = rightLand.position;
            }
        }
        playSound(true);

    }
    void RandomNewSpeed()
    {
        speed = Random.Range(0.3f, 0.9f);     //slow
    }
    void RandomNewPauseCounter()
    {
        HelicopterPauseCounter = Random.Range(15f, 30f);     //slow
    }
    void playSound(bool b)
    {
        if (b)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
    private void OnMouseDown()
    {
        if (helicopterPoint == 1 && helicopterPause)
        {
            HelicopterPauseCounter = 0;
        }
        else
        {
            speed *= 4;
        }
        gameManager.GetComponent<GameManager>().SoundPlay_Click();  //sound click
    }
}
