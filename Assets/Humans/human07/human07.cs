using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human07 : MonoBehaviour
{
    public Transform start;
    public Transform start2;
    public bool direction;
    public Transform startUp;

    Vector3 nextPosition;
    float step;
    float speed = 3f;
    float z;
    bool onRotate = false;
    SpriteRenderer spriteRenderer;
    bool IsDestroy = false;
    bool IsPlay = true;
    float counterTime = 2f;
    void Start()
    {
        counterTime = 3f;
        IsDestroy = false;
        IsPlay = true;
        z = transform.position.z;;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //speed = Random.Range(2.5f, 3.5f);
        //direction = Random.Range((int)0, 2) == 0 ? false : true;  // false = left -> right
        if (direction)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.transform.Rotate(0, 0, 30);
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.transform.Rotate(0, 0, -30);
        }

        transform.position = new Vector3(start.position.x, start.position.y, z);
        nextPosition = new Vector3(start2.position.x, start2.position.y, z);
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
        nextPosition = new Vector3(nextPosition.x, nextPosition.y, z);
    }

    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);

        if (counterTime<=0)
        {

            nextPosition = new Vector3(start.position.x, start.position.y, z);
            counterTime = 20;
            IsDestroy = true;
        }

        if (transform.position == nextPosition)
        {
            counterTime -= Time.deltaTime;
            if (IsDestroy)
            {
                gameObject.GetComponent<AudioSource>().Stop();
                Destroy(gameObject);
            }
            else
            {
                if (IsPlay)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    IsPlay = false;
                }
            }
        }
        if (onRotate)
        {
            if (direction)
            {
                spriteRenderer.transform.Rotate(Vector3.back * 4);
            }
            else
            {
                spriteRenderer.transform.Rotate(Vector3.forward * 4);
            }
        }
    }
    private void OnMouseDown()
    {
        nextPosition = new Vector3(startUp.position.x, startUp.position.y, nextPosition.z);

        IsDestroy = true;
        speed *= 9;
        onRotate = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
