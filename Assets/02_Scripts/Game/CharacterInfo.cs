using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    MainSys mainSys;

    //������� ����
    public float Life;
    public bool Dead;
    public bool Female;


    //���带 ����

    private AudioSource audiofx;
    public AudioClip c_jumpSound;
    public AudioClip c_attackSound;
    public AudioClip c_dodgeSound;

    void Awake()
    {

        mainSys = GameObject.Find("GameSystem").GetComponent<MainSys>();

    }

    void Start()
    {

        //�׽�Ʈ�� ����� �⺻���� ��� �ƴ����� ó��
        Dead = false;


    }


    // Update is called once per frame / Wow really?
    void Update()
    {
        if (Dead == true)
        {
            mainSys.Death = true;
        }

    }

}
