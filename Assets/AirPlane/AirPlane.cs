using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour
{
    //spawn position :
    [SerializeField] Transform rightPos1;
    [SerializeField] Transform rightPos2;
    [SerializeField] Transform leftPos1;
    [SerializeField] Transform leftPos2;
    [SerializeField] Sprite[] airplaneImages;   //table of image airplane / areoplane
    Rigidbody2D rb;

    float step;
    float speed = 1.5f;
    Vector3 NormalScaleBalloon = new Vector3(3.2f, 2.4f, 4f);
    Vector3 nextPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomNewType();
        RandomNewPosition();
        RandomNewSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);
        if (transform.position == nextPosition)
        {
            RandomNewType();
            RandomNewPosition();
            RandomNewSpeed();
        }
    }

    void RandomNewType()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = airplaneImages[Random.Range(0, airplaneImages.Length)];
    }
    void RandomNewPosition()
    {
        //random left or right
        bool right = Random.Range(0, 2) == 0 ? true : false;

        if (right)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            nextPosition = new Vector3(rightPos1.position.x, Random.Range(rightPos1.position.y, rightPos2.position.y), transform.position.z);
            transform.position = new Vector3(leftPos1.position.x, Random.Range(leftPos1.position.y, leftPos2.position.y), transform.position.z);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            nextPosition = new Vector3(Random.Range(leftPos1.position.x, leftPos2.position.x), Random.Range(leftPos1.position.y, leftPos2.position.y), transform.position.z);
            transform.position = new Vector3(Random.Range(rightPos1.position.x, rightPos2.position.x), Random.Range(rightPos1.position.y, rightPos2.position.y), transform.position.z);
        }
    }
    void RandomNewSpeed()
    {
        speed = Random.Range(0.7f, 1.5f);     //speed
    }
    public void ClickAirPlane()
    {
        speed = speed * 5;
    }
    private void OnMouseDown()
    {
        playSound();
        ClickAirPlane();
    }
    public void playSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
