using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour
{
    //spawn position :
    [SerializeField] Transform rightPos1;
    [SerializeField] Transform rightPos2;
    [SerializeField] Transform leftPos1;
    [SerializeField] Transform leftPos2;
    [SerializeField] Transform posFront;
    [SerializeField] Transform posBack;
    Rigidbody2D rb;

    float step;
    float speed = 0.1f;
    Vector3 NormalScaleBalloon = new Vector3(3.2f, 2.4f, 4f);
    Vector3 nextPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomNewScale();
        RandomNewPosition();
        RandomNewColor();
        RandomNewSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);
        if (transform.position==nextPosition)
        {
            RandomNewPosition();
            RandomNewColor();
            RandomNewScale();
            RandomNewSpeed();
        }
    }

    void RandomNewPosition()
    {
        //random left or right
        bool right = Random.Range(0, 2) == 0 ? true:false;

        if (right)
        {
            nextPosition = new Vector3(rightPos1.position.x, Random.Range(rightPos1.position.y, rightPos2.position.y), transform.position.z);
            transform.position = new Vector3(leftPos1.position.x, Random.Range(leftPos1.position.y, leftPos2.position.y), transform.position.z);
        }
        else
        {
            nextPosition = new Vector3(Random.Range(leftPos1.position.x, leftPos2.position.x), Random.Range(leftPos1.position.y, leftPos2.position.y), transform.position.z);
            transform.position = new Vector3(Random.Range(rightPos1.position.x, rightPos2.position.x), Random.Range(rightPos1.position.y, rightPos2.position.y), transform.position.z);
        }
        //speed = Random.Range(0.81f, 0.81f);

    }
    void RandomNewColor()
    {
        Color color;
        switch(Random.Range(0,5))
        {
            case 0: 
                color = Color.white;
                break;
            case 1:
                color = Color.cyan;
                break;
            case 2:
                color = Color.yellow;
                break;
            case 3:
                color = Color.grey;
                break;
            case 4:
                color = Color.green;
                break;
            default:
                color = Color.white;
                break;
        }
        transform.GetComponent<Renderer>().material.color = color;
    }
    void RandomNewScale()
    {
        if (Random.Range(0,2)==0)
        {
            gameObject.GetComponent<Transform>().localScale = NormalScaleBalloon * 1.4f;
            transform.position = new Vector3(transform.position.x, transform.position.y, posFront.position.z);    //front
        }
        else
        {
            gameObject.GetComponent<Transform>().localScale = NormalScaleBalloon;
            transform.position = new Vector3(transform.position.x, transform.position.y, posBack.position.z);     //back
            print(transform.position + "     " + GameObject.FindWithTag("BackGround").GetComponent<Transform>().position);
        }
    }
    void RandomNewSpeed()
    {
        speed = Random.Range(0.05f, 0.1f);     //slow
    }
    public void ClickBalloon()
    {
            speed = speed * 10;
    }
    private void OnMouseDown()
    {
        playSound();
        ClickBalloon();

    }
    public void playSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
