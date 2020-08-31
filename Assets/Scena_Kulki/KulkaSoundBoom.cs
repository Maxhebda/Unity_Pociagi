using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KulkaSoundBoom : MonoBehaviour
{
    [SerializeField] AudioClip[] myAudio;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = myAudio[Random.Range(0, myAudio.Length)];
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.5f);
    }
}
