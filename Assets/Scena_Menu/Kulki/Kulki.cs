using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kulki : MonoBehaviour
{
    GameObject soundClick;
    // Start is called before the first frame update
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
        SceneManager.LoadScene(2);
    }
}
