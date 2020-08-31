using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zegar01 : MonoBehaviour
{
    [SerializeField] Sprite[] imagesTimer;
    [SerializeField] GameObject sound;

    float liveTime;
    bool playSoundDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);  //delete parrent
        liveTime = Random.Range(20f, 40f);
        gameObject.GetComponent<SpriteRenderer>().sprite = imagesTimer[0];
        float skala = Random.Range(0.09f, 0.25f);
        gameObject.GetComponent<Transform>().localScale = new Vector3(skala, skala, skala);
        GameObject soundTmp = Instantiate(sound);
    }

    // Update is called once per frame
    void Update()
    {
        if (liveTime > 0)
        {
            liveTime -= Time.deltaTime;
        }
        if (playSoundDestroy && liveTime < 0.3f)
        {
            print(liveTime);
            GameObject soundTmp = Instantiate(sound);
            playSoundDestroy = false;
        }
        if (liveTime < 0 || gameObject.transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDrag()
    {
        liveTime = 0.3f;
    }
    private void OnMouseEnter()
    {
        liveTime = 0.3f;
    }
    private void OnMouseDown()
    {
        liveTime = 0.3f;
    }
}
