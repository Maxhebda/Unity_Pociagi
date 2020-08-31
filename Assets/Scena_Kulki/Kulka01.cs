using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kulka01 : MonoBehaviour
{
    [SerializeField] Sprite[] imagesBuuble;
    [SerializeField] Sprite imageBuubleBoom;
    [SerializeField] GameObject sound;

    float liveTime;
    bool playSoundDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        liveTime = Random.Range(15f, 40f);
        gameObject.GetComponent<SpriteRenderer>().sprite = imagesBuuble[Random.Range(0, imagesBuuble.Length)];
        float skala = Random.Range(0.3f, 0.8f);
        gameObject.GetComponent<Transform>().localScale = new Vector3(skala, skala, skala);
        GameObject soundTmp = Instantiate(sound);
    }

    // Update is called once per frame
    void Update()
    {
        if (liveTime>0)
        {
            liveTime -= Time.deltaTime;
        }
        if (playSoundDestroy && liveTime < 0.1f)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = imageBuubleBoom;
            GameObject soundTmp = Instantiate(sound);
            playSoundDestroy = false;
        }
        if (liveTime < 0 || gameObject.transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDrag()
    {
        liveTime = 0.1f;
    }
    private void OnMouseEnter()
    {
        liveTime = 0.1f;
    }
    private void OnMouseDown()
    {
        liveTime = 0.1f;
    }
}
