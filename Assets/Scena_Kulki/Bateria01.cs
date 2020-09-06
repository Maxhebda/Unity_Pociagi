using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria01 : MonoBehaviour
{
    [SerializeField] Sprite[] imagesBattery;
    [SerializeField] GameObject sound;

    float liveTime;
    bool playSoundDestroy = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
        liveTime = Random.Range(15f, 40f);
        gameObject.GetComponent<SpriteRenderer>().sprite = imagesBattery[Random.Range(0, imagesBattery.Length)];
        float skala = Random.Range(0.36f, 0.4f);
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
            GameObject soundTmp = Instantiate(sound);
            playSoundDestroy = false;
        }
        if (liveTime < 0 || gameObject.transform.position.y < -6f)
        {
            if (gameObject)
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
