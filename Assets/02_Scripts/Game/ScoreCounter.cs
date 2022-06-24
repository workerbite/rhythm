using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//도움이 되었던 영상 (https://www.youtube.com/watch?v=i1KmYHoXx80)
public class ScoreCounter : MonoBehaviour
{
    public Text EndScore;
    private int endscore;
    public int growthRate;
    public GameObject S;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public float Percentage;
    public float MaxScore;
    public float MinScore;


    public void Update()
    {
        MaxScore = (float)Songinfo.instance.TotalScore;
        MinScore = (float)Judgement.instance.nowscore;
        Percentage = (MinScore / MaxScore) * 100;
        if (endscore != Judgement.instance.nowscore && Judgement.instance.nowscore > endscore)
        {
            endscore += growthRate;
            Debug.Log("countup");
        }

        if (Percentage >= 97f)
        {
            S.gameObject.SetActive(true);
        }
        else if (Percentage >= 71f && 96f > Percentage)
        {
            A.gameObject.SetActive(true);
        }
        else if (Percentage >= 65f && 70f > Percentage)
        {
            B.gameObject.SetActive(true);
        }
        else if (Percentage >= 49f && 64f > Percentage)
        {
            C.gameObject.SetActive(true);
        }
        else if (Percentage >= 33f && 48f > Percentage)
        {
            D.gameObject.SetActive(true);
        }
        else if (Percentage >= 17f && 32f > Percentage)
        {
            E.gameObject.SetActive(true);
        }
        else
        {
            F.gameObject.SetActive(true);
        }



        EndScore.text = endscore.ToString();
    }
}
