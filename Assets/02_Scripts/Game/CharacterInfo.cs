using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    MainSys mainSys;

    //생명력을 위한
    public float Life;
    public bool Dead;
    public bool Female;


    //사운드를 위한

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

        //테스트용 생명력 기본제공 사망 아님으로 처리
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
