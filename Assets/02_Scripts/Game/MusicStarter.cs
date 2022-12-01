using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioData;
    public GameObject Mus;
    public float AudioAccel;
    private int TotalAccel;
    public static MusicStarter instance = null;

    private void Awake()
    {

    }

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MusicStarter"))
        {
            Debug.Log("musicstart");            
            audioData.Play(0);
            Judgement.instance.musicstart = true;
        }

        if (other.gameObject.CompareTag("End"))
        {
            Debug.Log("musicend = true");
            audioData.Pause();
            Judgement.instance.musicend = true;
        }

        if (other.gameObject.CompareTag("SpeedChange"))
        {
            Debug.Log("SpeedUp");
            audioData.pitch = audioData.pitch + AudioAccel;
        }
    }
}

