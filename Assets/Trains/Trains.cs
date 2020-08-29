using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Trains : MonoBehaviour
{
    [SerializeField] GameObject[] train;
    [SerializeField] GameObject semaforGate;

    [SerializeField] Transform[] leftSpawn;
    [SerializeField] Transform[] rightSpawn;
    [SerializeField] Transform[] leftStop;
    [SerializeField] Transform[] rightStop;

    [SerializeField] GameObject[] soundsHorn;

    Vector3 nextPosition;
    Vector3 endPosition;
    byte positionCounter = 0;

    float spawnTime = 10f;
    bool spawnEnabled = true;
    bool trainIsActive = false;
    float speed = 5f;
    float step;

    bool TrainDirection = false;    //false left, true right
    int TrainNumber = 0;
    void Start()
    {
        RandomSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnabled)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime < 0)
            {
                spawnEnabled = false;
                RandomNewTrain();
                RandomSpawnTime();
                trainIsActive = true;
            }
        }
        // if train is active ----> run
        if (trainIsActive)  //  if train is ON
        {
            step = speed * Time.deltaTime;
            train[TrainNumber].GetComponent<Transform>().position = Vector3.MoveTowards(train[TrainNumber].GetComponent<Transform>().position, nextPosition, step);
            if (train[TrainNumber].GetComponent<Transform>().position == nextPosition)
            {
                if (positionCounter==0)     //stop
                {
                    if (semaforGate.GetComponent<Semafor>().barrierIsOpen==false)   //if barrier semaphor is close
                    {
                        positionCounter = 1;
                        nextPosition = endPosition;
                        train[TrainNumber].GetComponent<Animator>().enabled = true;     // on animation
                    }
                    else
                    {
                        train[TrainNumber].GetComponent<Animator>().enabled = false;    // off animation
                    }
                }
                else                        //end of route 
                {
                    spawnEnabled = true;
                    trainIsActive = false;  //train is OFF
                    // OFF animate
                    train[TrainNumber].GetComponent<Animator>().enabled = false;
                    openBarrier(); //barrier must is open
                    RandomSpawnTime();
                }
            }
        }

    }
    void RandomSpawnTime()
    {
        spawnTime = Random.Range(10, 40);
    }
    void RandomNewTrain()
    {
        TrainDirection = Random.Range(0, 2) == (byte)0 ? false : true;

        TrainNumber = Random.Range(0, train.Length); //random Train
        //TrainNumber = 6;
        positionCounter = 0;
        if (TrainDirection)     // go left
        {
            train[TrainNumber].GetComponent<SpriteRenderer>().flipX = false;
            train[TrainNumber].GetComponent<Transform>().position = rightSpawn[TrainNumber].position;
            nextPosition = rightStop[TrainNumber].position;
            endPosition = leftSpawn[TrainNumber].position;
        }
        else                    // go right
        {
            train[TrainNumber].GetComponent<SpriteRenderer>().flipX = true;
            train[TrainNumber].GetComponent<Transform>().position = leftSpawn[TrainNumber].position;
            nextPosition = leftStop[TrainNumber].position;
            endPosition = rightSpawn[TrainNumber].position;
        }
        // ON animate
        train[TrainNumber].GetComponent<Animator>().enabled = true;

        // activate semaphor
        if ((int)(Random.Range(0, 2)) == 0)
            { 
                closeBarrier(); 
            }

        // play horn Train sound
        playTrainHorn();
    }
    void closeBarrier()
    {
        if (semaforGate.GetComponent<Semafor>().barrierIsOpen == true)
        {
            semaforGate.GetComponent<Semafor>().resetSet();
            semaforGate.GetComponent<Semafor>().closingBarrier = true;
            semaforGate.GetComponent<Semafor>().openingBarrier = false;
            semaforGate.GetComponent<Semafor>().playSemaphoreSound(true);
            semaforGate.GetComponent<Semafor>().barrierIsOpen = null;
        }
    }
    void openBarrier()
    {
        if (semaforGate.GetComponent<Semafor>().barrierIsOpen == false)
        {
            semaforGate.GetComponent<Semafor>().resetSet();
            semaforGate.GetComponent<Semafor>().closingBarrier = false;
            semaforGate.GetComponent<Semafor>().openingBarrier = true;
            //semaforGate.GetComponent<Semafor>().playSemaphoreSound(true);
            semaforGate.GetComponent<Semafor>().barrierIsOpen = null;
        }
    }
    void playTrainHorn()
    {
        int r = Random.Range(0, soundsHorn.Length);
        soundsHorn[r].GetComponent<AudioSource>().Play();
    }
    public void playTrainHornShort()
    {
        soundsHorn[5].GetComponent<AudioSource>().Play();
    }
}
