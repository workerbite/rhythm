using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSys : MonoBehaviour
{
    Levelplayer levelPlayer;
    MusicStarter musicstarter;

    public Text timeTimer;
    public Text Score;
    public Text thisScore;
    private float realtime;
    private int simpletime;
    private bool timepause;
    public GameObject Ninjafan;
    public GameObject Black;
    public GameObject Gameover;
    public GameObject Gameclear;
    public GameObject Gotoselect;
    public int StartPosition;
    public bool Death;

    void Awake()
    {


        //게임 룰 관련 초기화

        Death = false;
        timepause = false;
        
        levelPlayer = GameObject.Find("LevelMaker").GetComponent<Levelplayer>();
        musicstarter = GameObject.Find("MusicStarter").GetComponent<MusicStarter>();

        Application.targetFrameRate = 60;
        //UI팝업 관련 초기화
        Black.gameObject.SetActive(false);
        Gameover.gameObject.SetActive(false);
        Gameclear.gameObject.SetActive(false);
        Gotoselect.gameObject.SetActive(false);
        Ninjafan.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Judgement.instance.bgstop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Judgement.instance.speedmult;

        if (Judgement.instance.Camera == true)
        {
            StartCoroutine(Cameraplay());
        }

        if (Judgement.instance.CameraShot == true)
        {
            StartCoroutine(Cameraend());
        }


        if (Judgement.instance.musicend == true)
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
        Score.text = Judgement.instance.nowscore.ToString();
        thisScore.text = Judgement.instance.totalscore.ToString();

        if (Death == true)
        {
            levelPlayer.start = false;
            Black.gameObject.SetActive(true);
            Gotoselect.gameObject.SetActive(true);
            Gameover.gameObject.SetActive(true);
            timepause = true;
            musicstarter.audioData.Pause();
            Judgement.instance.bgstop = true;
        }
        else
        {
            return;
        }

    }

    IEnumerator OpenResult()
    {
        yield return new WaitForSecondsRealtime(3f);
        Gameclear.gameObject.SetActive(true);
        Debug.Log("yataa");
        yield return new WaitForSecondsRealtime(999999f);
    }

    IEnumerator Cameraplay()
    {       
        Ninjafan.gameObject.SetActive(true);
        Ninjafan.gameObject.GetComponent<Animator>().Play("ninjarun");
        Debug.Log("domo ninjadesu");
        yield return new WaitForSeconds(3.4f);
    }
    IEnumerator Cameraend()
    {
        //Ninjafan.gameObject.SetActive(true);
        Ninjafan.gameObject.GetComponent<Animator>().Play("ninjagood");
        Debug.Log("otsukaresan");
        yield return new WaitForSeconds(2.6f);
        Ninjafan.gameObject.SetActive(false);
    }

}
