using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human02 : MonoBehaviour
{
    public Transform startLeft;
    public Transform startRight;
    public Transform startUp1;
    public Transform startUp2;

    bool direction;
    Vector3 nextPosition;
    float step;
    float speed = 1f;
    bool onRotate = false;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        speed = Random.Range(0.3f, 0.7f);
        direction = Random.Range((int)0, 2) == 0 ? false : true;  // false = left -> right
        if (direction)
        {
            transform.position = startLeft.position;
            nextPosition = startRight.position;
            spriteRenderer.flipX = true;
        }
        else
        {
            transform.position = startRight.position;
            nextPosition = startLeft.position;
            spriteRenderer.flipX = false;
        }
    }

    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);
        if (transform.position == nextPosition)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            Destroy(gameObject);
        }
        if (onRotate)
        {
            if (direction)
            {
                spriteRenderer.transform.Rotate(Vector3.back * 2);
            }
            else
            {
                spriteRenderer.transform.Rotate(Vector3.forward * 2);
            }
        }
    }
    private void OnMouseDown()
    {
        if (!direction)
        {
            nextPosition = new Vector3(Random.Range(startUp1.position.x, transform.position.x), startUp1.position.y, nextPosition.z);
        }
        else
        {
            nextPosition = new Vector3(Random.Range(transform.position.x, startUp2.position.x), startUp1.position.y, nextPosition.z);
        }
        speed *= 3;
        onRotate = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
