using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train03Horn : MonoBehaviour
{
    GameObject train;
    // Start is called before the first frame update
    void Start()
    {
        train = GameObject.FindWithTag("Train");

    }

    private void OnMouseDown()
    {
        train.GetComponent<Trains>().playTrainHornShort();
    }
}