using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRandom : MonoBehaviour
{
    public GameObject human01;
    public GameObject human02;
    public GameObject human03;
    public GameObject human04;
    public GameObject human05;

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
            counter = Random.Range(0, 5);
            switch(Random.Range((int)0,5))
            {
                case 0:
                    addHuman01();
                    break;
                case 1:
                    addHuman02();
                    break;
                case 2:
                    addHuman03();
                    break;
                case 3:
                    addHuman04();
                    break;
                case 4:
                    addHuman05();
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
    private void addHuman03()
    {
        GameObject obj = Instantiate(human03, gameObject.transform);
        obj.GetComponent<human03>().startLeft = startLeftGlobal;
        obj.GetComponent<human03>().startRight = startRightGlobal;
        obj.GetComponent<human03>().startUp1 = startUp1Global;
        obj.GetComponent<human03>().startUp2 = startUp2Global;
    }
    private void addHuman04()
    {
        GameObject obj = Instantiate(human04, gameObject.transform);
        obj.GetComponent<human04>().startLeft = startLeftGlobal;
        obj.GetComponent<human04>().startRight = startRightGlobal;
        obj.GetComponent<human04>().startUp1 = startUp1Global;
        obj.GetComponent<human04>().startUp2 = startUp2Global;
    }
    private void addHuman05()
    {
        GameObject obj = Instantiate(human05, gameObject.transform);
        obj.GetComponent<human05>().startLeft = startLeftGlobal;
        obj.GetComponent<human05>().startRight = startRightGlobal;
        obj.GetComponent<human05>().startUp1 = startUp1Global;
        obj.GetComponent<human05>().startUp2 = startUp2Global;
    }
}
