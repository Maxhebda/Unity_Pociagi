using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human03 : MonoBehaviour
{
    public Transform startLeft;
    public Transform startRight;
    public Transform startUp1;
    public Transform startUp2;

    bool direction;
    Vector3 nextPosition;
    float step;
    float speed = 3f;
    float z;
    bool onRotate = false;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        z = transform.position.z;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        speed = Random.Range(3f, 6f);
        direction = Random.Range((int)0, 2) == 0 ? false : true;  // false = left -> right
        if (direction)
        {
            transform.position = startLeft.position;
            nextPosition = startRight.position;
            spriteRenderer.flipX = false;
        }
        else
        {
            transform.position = startRight.position;
            nextPosition = startLeft.position;
            spriteRenderer.flipX = true;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
        nextPosition = new Vector3(nextPosition.x, nextPosition.y, z);
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
