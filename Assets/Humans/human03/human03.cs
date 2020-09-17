using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class human03 : MonoBehaviour
{
    public Transform startLeft;
    public Transform startRight;
    public Transform startUp1;
    public Transform startUp2;
    public GameObject human07Boy;

    public Transform startLeftBoy;
    public Transform startRightBoy;
    public Transform startLeft2Boy;
    public Transform startRight2Boy;

    bool direction;
    Vector3 nextPosition;
    float step;
    float speed = 3f;
    float z;
    bool onRotate = false;
    bool onlyOneBoy = true;
    bool notclickBoy = true;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        onlyOneBoy = true;
        notclickBoy = true;
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

            // create boy
            if (onlyOneBoy && notclickBoy)
            {
                GameObject obj = Instantiate(human07Boy, GameObject.FindWithTag("Human").transform);
                if (direction)
                {
                    obj.GetComponent<human07>().start = startLeftBoy;
                    obj.GetComponent<human07>().start2 = startLeft2Boy;
                    obj.GetComponent<human07>().startUp = startUp2;
                    obj.GetComponent<human07>().start = startRightBoy;
                    obj.GetComponent<human07>().start2 = startRight2Boy;
                    obj.GetComponent<human07>().startUp = startUp1;
                }
                else
                {
                    obj.GetComponent<human07>().start = startLeftBoy;
                    obj.GetComponent<human07>().start2 = startLeft2Boy;
                    obj.GetComponent<human07>().startUp = startUp2;
                }
                obj.GetComponent<human07>().direction = direction;
                onlyOneBoy = false;
            }

            Destroy(gameObject,1f);
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
        notclickBoy = false;
        speed *= 3;
        onRotate = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
