using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judgement : MonoBehaviour
{

    public static Judgement instance = null;

    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            //DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }

    void Update()
    {

    }

    //게임 내에서 씬이동시 유지하고 픈 골드 값(변수)
    public int bgstage = 0;
    public bool bgstop = false;

    //진짜 판정 계열
    public bool thiscool = false;
    public bool thisgood = false;
    public bool thisdcool = false;
    public bool thisdgood = false;
    public float bonusjudge = 0;
    

    //스코어 관련
    public int totalscore = 0;
    public int nowscore = 0;

    //게임 진행(Mainsys) 관련
    public bool musicstart = false;
    public bool musicend = false;
    public float speedmult = 0;
    //게임 진행(Mainsys) 카메라 관련
    public bool Camera = false;
    public bool CameraShot = false;
    public bool CameraPerpect = false;
    public bool CameraLittleUp = false;
    public bool CameraUp = false;
    public bool CameraTooUp = false;
    public bool CameraLittleDown = false;
    public bool CameraDown = false;
    public bool CameraTooDown = false;
    public bool CameraFail = false;
    public float Hight = 0;



    public int GetTalkNumber;
    public int TotalTalkNumber;
    public bool TalkClose;
    public bool TalkDisable;
    public int emotion;
    public int mouse;
    public bool ouch;
    public bool jumpsuccess;

    

    public int GetNPCNumber;
    public int TotalNPCNumber;
    public bool NPCClose;
    public bool NPCDisable;
    public bool Attack;
    public bool Jump;
    public bool Dodge;

}