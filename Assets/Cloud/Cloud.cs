using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] Transform Cloudposition1;
    [SerializeField] Transform Cloudposition2;
    float speed = 0.02f;
    float step;
    Vector3 nextPosition;
    void Start()
    {
        RandomNewPosition();
        //transform.position = new Vector3(Random.Range(Cloudposition2.position.x, Cloudposition1.position.x), Cloudposition1.position.y, Cloudposition1.position.z);
    }


    void Update()
    {
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);
        if (transform.position == nextPosition)
        {
            RandomNewPosition();
            RandomMirror();
        }
    }
    void RandomNewPosition()
    {
        if (Random.Range(0, 2) == 0)
        {
            transform.position = Cloudposition2.position;
            nextPosition = Cloudposition1.position;
        }
        else
        {
            transform.position = Cloudposition1.position;
            nextPosition = Cloudposition2.position;
        }
    }
    void RandomMirror()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = Random.Range(0, 2)==0?true:false;
    }
}
