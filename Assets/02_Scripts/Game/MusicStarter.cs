using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioData;
    public GameObject Mus;
    public static MusicStarter instance = null;

    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MusicStarter"))
        {
            Debug.Log("musicstart");
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Judgement.instance.musicstart = true;
        }

        if (other.gameObject.CompareTag("End"))
        {
            Debug.Log("musicend = true");
            audioData = GetComponent<AudioSource>();
            audioData.Pause();
            Judgement.instance.musicend = true;
        }
    }
}

