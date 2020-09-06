using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBateria : MonoBehaviour
{
    [SerializeField] GameObject myaudio;
    [SerializeField] GameObject bateriaPrefab;
    float licz;
    // Start is called before the first frame update
    void Start()
    {
        licz = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (licz > 0)
        {
            licz -= Time.deltaTime;
        }
    }
    private void OnMouseDrag()
    {
        if (licz < 0)
        {
            licz = 0.20f;
            GameObject audioTmp = Instantiate(myaudio);
            GameObject bateria = Instantiate(bateriaPrefab);
        }
    }
    private void OnMouseEnter()
    {
        if (licz < 0)
        {
            licz = 0.20f;
            GameObject audioTmp = Instantiate(myaudio);
            GameObject bateria = Instantiate(bateriaPrefab);
        }
    }
}
