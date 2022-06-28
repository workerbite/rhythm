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

            //캐릭터 최대 점프 높이는 0.265기준으로 잡음 땅에 있을때는 -2.87 >= -2.8f && Judgement.instance.Hight < 3.5f
            if (Judgement.instance.Hight >= 3.0f && Judgement.instance.Hight <= 3.43f)
            {
                Debug.Log("CameraPerpect");
                Judgement.instance.nowscore += 400;
                Judgement.instance.CameraPerpect = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 3.43f && Judgement.instance.Hight <= 3.9)
            {
                Debug.Log("CameraLittleUp");
                Judgement.instance.nowscore += 300;
                Judgement.instance.CameraLittleUp = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 3.9f && Judgement.instance.Hight <= 4.4f)
            {
                Debug.Log("CameraUp");
                Judgement.instance.nowscore += 200;
                Judgement.instance.CameraUp = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 4.4f && Judgement.instance.Hight <= 5.0f)
            {
                Debug.Log("CameraTooUp");
                Judgement.instance.nowscore += 100;
                Judgement.instance.CameraTooUp = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight >= 2.7f && Judgement.instance.Hight < 3.0f)
            {
                Debug.Log("CameraLittleDown");
                Judgement.instance.nowscore += 300;
                Judgement.instance.CameraLittleDown = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight >= 2.2f && Judgement.instance.Hight < 2.7f)
            {
                Debug.Log("CameraDown");
                Judgement.instance.nowscore += 200;
                Judgement.instance.CameraDown = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight >= 1.5f && Judgement.instance.Hight < 2.2f)
            {
                Debug.Log("CameraTooDown");
                Judgement.instance.nowscore += 100;
                Judgement.instance.CameraTooDown = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight < 1.5f)
            {
                Debug.Log("CameraFail");
                Judgement.instance.CameraFail = true;
                StartCoroutine(CoolDown());
            }
            else if (Judgement.instance.Hight > 5.0f)
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
        yield return new WaitForSecondsRealtime(0.3f);
        Judgement.instance.CameraShot = false;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Judgement.instance.CameraPerpect = false;
        Judgement.instance.CameraLittleUp = false;
        Judgement.instance.CameraUp = false;
        Judgement.instance.CameraTooUp = false;
        Judgement.instance.CameraLittleDown = false;
        Judgement.instance.CameraDown = false;
        Judgement.instance.CameraTooDown = false;
        Judgement.instance.CameraFail = false;
        Judgement.instance.Hight = 0f;

    }
}
