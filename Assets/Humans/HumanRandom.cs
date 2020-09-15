using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRandom : MonoBehaviour
{
    public GameObject human01;

    public Transform startLeftGlobal;
    public Transform startRightGlobal;
    public Transform startUp1Global;
    public Transform startUp2Global;

    float counter = 0;
    void Start()
    {
        counter = Random.Range(5, 10);
    }

    void Update()
    {

        counter-=Time.deltaTime;
        if (counter < 0)
        {
            counter = Random.Range(5, 10);
            addHuman01();
        }
    }
    private void addHuman01()
    {
        GameObject obj = Instantiate(human01, gameObject.transform);
        obj.transform.parent = gameObject.transform;
        obj.GetComponent<human01>().startLeft = startLeftGlobal;
        obj.GetComponent<human01>().startRight = startRightGlobal;
        obj.GetComponent<human01>().startUp1 = startUp1Global;
        obj.GetComponent<human01>().startUp2 = startUp2Global;
    }

}
