using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CameraActive());

            //캐릭터 최대 점프 높이는 0.265기준으로 잡음
            if(Judgement.instance.Hight >= -0.2f && Judgement.instance.Hight < 0.5f)
            {
                Debug.Log("CameraOk");
                Judgement.instance.nowscore += 400;
                Judgement.instance.CameraOk = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 0.5f && Judgement.instance.Hight <= 1.1f)
            {
                Debug.Log("CameraUp");
                Judgement.instance.nowscore += 300;
                Judgement.instance.CameraUp = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 1.1f && Judgement.instance.Hight <= 1.7f)
            {
                Debug.Log("CameraTooUp");
                Judgement.instance.nowscore += 200;
                Judgement.instance.CameraTooUp = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight >= -0.8f && Judgement.instance.Hight < -0.2f)
            {
                Debug.Log("CameraDown");
                Judgement.instance.nowscore += 300;
                Judgement.instance.CameraDown = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight >= -1.5f && Judgement.instance.Hight < -0.8f)
            {
                Debug.Log("CameraTooDown");
                Judgement.instance.nowscore += 200;
                Judgement.instance.CameraTooDown = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight >= -0.8f)
            {
                Debug.Log("CameraFail");
                Judgement.instance.CameraFail = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 1.7f)
            {
                Debug.Log("CameraFail");
                Judgement.instance.CameraFail = true;
                StartCoroutine(CoolDown());
            }
        }
    }
    IEnumerator CameraActive()
    {
        Judgement.instance.CameraShot = true;
        yield return new WaitForSecondsRealtime(0.1f);
        Judgement.instance.CameraShot = false;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Judgement.instance.CameraOk = false;
        Judgement.instance.CameraUp = false;
        Judgement.instance.CameraTooUp = false;
        Judgement.instance.CameraDown = false;
        Judgement.instance.CameraTooDown = false;
        Judgement.instance.CameraFail = false;

    }
}
