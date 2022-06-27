using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSys : MonoBehaviour
{
    Levelplayer levelPlayer;
    //Minimapplayer minimapPlayer;

    public Text timeTimer;
    public Text Score;
    public Text thisScore;
    private int thisscore;
    private float realtime;
    private int simpletime;
    private bool timepause;
    public GameObject Ninjafan;
    public GameObject speedup;
    public GameObject Black;
    public GameObject Gameover;
    public GameObject Gameclear;
    public GameObject Gotoselect;
    public GameObject Picture;
    public GameObject Chara;
    public int StartPosition;
    public bool Death;
    public bool Clear;


    public float pitchValue = 1.0f;
    public float volumeValue;

    private float _subSpeedmult;

    void Awake()
    {

        Death = false;
        timepause = false;
        levelPlayer = GameObject.Find("LevelMaker").GetComponent<Levelplayer>();
        //minimapPlayer = GameObject.Find("MinimapMaker").GetComponent<Minimapplayer>();


        Application.targetFrameRate = 60;

        Black.gameObject.SetActive(false);
        Gameover.gameObject.SetActive(false);
        Gameclear.gameObject.SetActive(false);
        Gotoselect.gameObject.SetActive(false);
        Ninjafan.gameObject.SetActive(false);
        Picture.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        speedup.gameObject.GetComponent<Animator>().Play("speed notthing");
        StartCoroutine(aniPlay());
    }

    // Update is called once per frame
    void Update()
    {
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


        thisscore = Songinfo.instance.TotalScore;
        Clear = Judgement.instance.musicend;
        Time.timeScale = Songinfo.instance.Speedmult;

        if (Judgement.instance.Camera == true)
        {
            StartCoroutine(Cameraplay());
        }

        if (Judgement.instance.CameraShot == true)
        {
            StartCoroutine(Cameraend());
        }


        if (Clear == true)
        {
            StartCoroutine(OpenResult());
            StartPosition = 20;
        }

        if (timepause == false)
        {
            realtime += Time.deltaTime * 1;
            simpletime = (int)realtime;
        }

        timeTimer.text = simpletime.ToString(); //경과시간 출력기
        Score.text = simpletime.ToString();
        thisScore.text = thisscore.ToString();

        if (Death == true)
        {
            levelPlayer.start = false;
            //minimapPlayer.start = false;
            Black.gameObject.SetActive(true);
            Gotoselect.gameObject.SetActive(true);
            Gameover.gameObject.SetActive(true);
            speedup.gameObject.SetActive(false);
            timepause = true;
            MusicStarter.instance.audioData.Pause();
        }
        else
        {
            return;
        }

    }

    IEnumerator aniPlay()
    {
        yield return new WaitForSecondsRealtime(Songinfo.instance.gear1);
        Songinfo.instance.Speedmult = Songinfo.instance.Speedmult + Songinfo.instance.gear1Speed;
        speedup.gameObject.GetComponent<Animator>().Play("speedup");
        //pitchValue = 1.2f;
        Debug.Log("speedup1");

        yield return new WaitForSecondsRealtime(Songinfo.instance.gear2);
        Songinfo.instance.Speedmult = Songinfo.instance.Speedmult + Songinfo.instance.gear2Speed;
        speedup.gameObject.GetComponent<Animator>().Play("speedup2");
        //pitchValue = 1.5f;
        Debug.Log("speedup2");

        yield return new WaitForSecondsRealtime(Songinfo.instance.gear3);
        Songinfo.instance.Speedmult = Songinfo.instance.Speedmult + Songinfo.instance.gear3Speed;
        //pitchValue = 1.8f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup");
        Debug.Log("speedup3");

        yield return new WaitForSecondsRealtime(Songinfo.instance.gear4);
        Songinfo.instance.Speedmult = Songinfo.instance.Speedmult + Songinfo.instance.gear4Speed;
        //pitchValue = 2.1f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup2");
        Debug.Log("speedup4");

        yield return new WaitForSecondsRealtime(Songinfo.instance.gear5);
        Songinfo.instance.Speedmult = Songinfo.instance.Speedmult + Songinfo.instance.gear5Speed;
        //pitchValue = 2.4f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup");
        Debug.Log("speedup5");
    }

    IEnumerator OpenResult()
    {
        yield return new WaitForSecondsRealtime(3f);
        Gameclear.gameObject.SetActive(true);
        Debug.Log("yataa");
    }

    IEnumerator Cameraplay()
    {       
        Ninjafan.gameObject.SetActive(true);
        Ninjafan.gameObject.GetComponent<Animator>().Play("ninjarun");
        Debug.Log("domo ninjadesu");
        yield return new WaitForSecondsRealtime(3.4f);
    }
    IEnumerator Cameraend()
    {
        //Ninjafan.gameObject.SetActive(true);
        Ninjafan.gameObject.GetComponent<Animator>().Play("ninjagood");
        Debug.Log("otsukaresan");
        yield return new WaitForSecondsRealtime(3.4f);
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
