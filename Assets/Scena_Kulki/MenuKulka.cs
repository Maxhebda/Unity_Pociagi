using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKulka : MonoBehaviour
{
    [SerializeField] GameObject myaudio;
    [SerializeField] GameObject kulkaPrefab;
    float licz;
    // Start is called before the first frame update
    void Start()
    {
        licz = 0.05f;
     }

    // Update is called once per frame
    void Update()
    {
        if (licz>0)
        {
            licz -= Time.deltaTime;
        }
    }
    private void OnMouseDrag()
    {
        if (licz < 0)
        {
            licz = 0.05f;
            GameObject audioTmp = Instantiate(myaudio);
            GameObject kulka = Instantiate(kulkaPrefab);
        }
    }
}
