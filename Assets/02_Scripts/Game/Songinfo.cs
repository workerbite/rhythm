using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Songinfo : MonoBehaviour
{
    public int TotalScore = 0;
    public int BG = 1;

    //사운드를 위한

    private AudioSource audiofx;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip dodgeSound;

    //[Header("1Speedmult = 100BPM")]
    public float StartSpeedmult = 0f;


    void Awake()
    {
        //사운드 재생기 설정 (이건 바꿔야 함)
        this.audiofx = GetComponent<AudioSource>();

        TotalScore = 4800;
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "Jump":
                audiofx.clip = jumpSound;
                break;

            case "Attack":
                audiofx.clip = attackSound;
                break;

            case "Dodge":
                audiofx.clip = dodgeSound;
                break;
        }

        audiofx.Play();
    }

    private void Start()
    {
        Judgement.instance.speedmult = StartSpeedmult;
        Judgement.instance.totalscore = TotalScore;
        Judgement.instance.bgstage = BG;
    }

    void Update()
    {
        if (Judgement.instance.AttackSound == true)
            StartCoroutine("AttackPlay");
        if (Judgement.instance.DodgeSound == true)
            StartCoroutine("DodgePlay");
        if (Judgement.instance.JumpSound == true)
            StartCoroutine("JumpPlay");           
    }

    IEnumerator AttackPlay()
    {
        PlaySound("Attack");
        yield return new WaitForFixedUpdate();
        Judgement.instance.AttackSound = false;
    }

    IEnumerator DodgePlay()
    {
        PlaySound("Dodge");
        yield return new WaitForFixedUpdate();
        Judgement.instance.DodgeSound = false;
    }

    IEnumerator JumpPlay()
    {
        PlaySound("Jump");
        yield return new WaitForFixedUpdate();
        Judgement.instance.JumpSound = false;
    }


}