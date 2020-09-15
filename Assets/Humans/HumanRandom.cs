using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRandom : MonoBehaviour
{
    public GameObject human01;
    public GameObject human02;

    public Transform startLeftGlobal;
    public Transform startRightGlobal;
    public Transform startUp1Global;
    public Transform startUp2Global;

    float counter = 0;
    void Start()
    {
        counter = Random.Range(2, 10);
    }

    void Update()
    {

        counter-=Time.deltaTime;
        if (counter < 0)
        {
            counter = Random.Range(0, 13);
            switch(Random.Range((int)0,2))
            {
                case 0:
                    addHuman01();
                    break;
                case 1:
                    addHuman02();
                    break;
            }
        }
    }
    private void addHuman01()
    {
        GameObject obj = Instantiate(human01, gameObject.transform);
        obj.GetComponent<human01>().startLeft = startLeftGlobal;
        obj.GetComponent<human01>().startRight = startRightGlobal;
        obj.GetComponent<human01>().startUp1 = startUp1Global;
        obj.GetComponent<human01>().startUp2 = startUp2Global;
    }
    private void addHuman02()
    {
        GameObject obj = Instantiate(human02, gameObject.transform);
        obj.GetComponent<human02>().startLeft = startLeftGlobal;
        obj.GetComponent<human02>().startRight = startRightGlobal;
        obj.GetComponent<human02>().startUp1 = startUp1Global;
        obj.GetComponent<human02>().startUp2 = startUp2Global;
    }

}
