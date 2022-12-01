using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    MainSys mainSys;

    //공격,점프 성능을 위한
    public float ACool;
    public float ATime;
    public float JCool;
    public float JTime;


    //생명력을 위한
    public float Life;
    public bool Dead;
    public int charanumber;



    //판정을 위한
    public GameObject Cool;
    public GameObject Good;
    public Transform JudgeLocation;
    public float bonusJudge;

    //카메라 판정을 위한
    public GameObject Picture;
    public GameObject Chara;

    void Awake()
    {       
        mainSys = GameObject.Find("GameSystem").GetComponent<MainSys>();
        Picture.gameObject.SetActive(false);
    }

    void Start()
    {

        //테스트용 생명력 기본제공 사망 아님으로 처리
        Dead = false;

        Invoke("JudgementBonus",1f);

    }


    // Update is called once per frame / Wow really?
    void Update()
    {
        if (Dead == true)
        {
            mainSys.Death = true;
        }

        if (Judgement.instance.thiscool == true)
        {
            Instantiate(Cool, JudgeLocation.position, JudgeLocation.rotation);
            Debug.Log("docool");
        }
            
        if (Judgement.instance.thisgood == true)
        {
            Instantiate(Good, JudgeLocation.position, JudgeLocation.rotation);
            Debug.Log("dogool");
        }
        if (Judgement.instance.thisdcool == true)
        {
            Instantiate(Cool, JudgeLocation.position, JudgeLocation.rotation);
            Debug.Log("docool");
        }
        if (Judgement.instance.thisdgood == true)
        {
            Instantiate(Good, JudgeLocation.position, JudgeLocation.rotation);
            Debug.Log("dogool");
        }





        if (Judgement.instance.CameraPerpect == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("안이동");
        }
        else if (Judgement.instance.CameraLittleUp == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, 0.08f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }
        else if (Judgement.instance.CameraUp == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, 0.15f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }
        else if (Judgement.instance.CameraTooUp == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, 0.35f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }
        else if (Judgement.instance.CameraLittleDown == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, -0.09f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }
        else if (Judgement.instance.CameraDown == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, -0.17f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }
        else if (Judgement.instance.CameraTooDown == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, -0.35f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }
        else if (Judgement.instance.CameraFail == true)
        {
            Chara.gameObject.transform.localPosition = new Vector3(0, 100f, 0);
            StartCoroutine(OpenPicture());
            Debug.Log("이동");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Health"))
        {
            Life = 999;
        }
    }

    void JudgementBonus()
    {
       Judgement.instance.bonusjudge = bonusJudge;
    }

    IEnumerator OpenPicture()
    {
        yield return new WaitForSecondsRealtime(1f);
        Picture.gameObject.SetActive(true);
        Debug.Log("hereyouare");
        yield return new WaitForSecondsRealtime(2f);
        Picture.gameObject.SetActive(false);
    }

}
