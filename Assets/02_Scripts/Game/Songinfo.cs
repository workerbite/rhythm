using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Songinfo : MonoBehaviour
{

    public static Songinfo instance = null;

    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
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
    public int TotalScore = 0;
    public int TotalLeft = 0;
    public int TotalRight = 0;
    public int TotalJump = 0;
    public int TotalPicture = 0;
    public float gear1;
    public float gear2;
    public float gear3;
    public float gear4;
    public float gear5;
    public float gear1Speed;
    public float gear2Speed;
    public float gear3Speed;
    public float gear4Speed;
    public float gear5Speed;
    public float Speedmult = 0;
    public string Memo;
}