using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{

    //������� ����
    public float Life;
    public bool Death;


    //���带 ����

    private AudioSource audiofx;
    public AudioClip c_jumpSound;
    public AudioClip c_attackSound;
    public AudioClip c_dodgeSound;


    void Start()
    {

        //�׽�Ʈ�� ����� �⺻���� ��� �ƴ����� ó��
        Death = false;


    }


    // Update is called once per frame / Wow really?
    void Update()
    {


    }

}
