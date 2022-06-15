using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainSys : MonoBehaviour
{
    Levelplayer levelPlayer;
    //Minimapplayer minimapPlayer;

    public Text timeTimer;
    public Text Score;
    private float realtime;
    private int simpletime;
    private int playerint;
    private bool timepause;
    public float speedmult;
    public GameObject speedup;
    public GameObject Black;
    public GameObject Gameover;
    public GameObject Gotoselect;
    public int StartPosition;
    public float gear1;
    public float gear2;
    public float gear3;
    public float gear4;
    public float gear5;
    public bool Death;




    private AudioSource audioSource;
    public float pitchValue = 1.0f;
    public float volumeValue;




    void Awake()
    {
        Death = false;
        timepause = false;
        levelPlayer = GameObject.Find("LevelMaker").GetComponent<Levelplayer>();
        //minimapPlayer = GameObject.Find("MinimapMaker").GetComponent<Minimapplayer>();

        audioSource = GetComponent<AudioSource>();

        Application.targetFrameRate = 60;

        Black.gameObject.SetActive(false);
        Gameover.gameObject.SetActive(false);
        Gotoselect.gameObject.SetActive(false);
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
        Time.timeScale = speedmult;
        audioSource.pitch = pitchValue;
        audioSource.volume = volumeValue;

        if (timepause == false)
        {
            realtime += Time.deltaTime * 1;
            simpletime = (int)realtime;
        }

        timeTimer.text = simpletime.ToString(); //경과시간 출력기
        Score.text = simpletime.ToString();

        if (Death == true)
        {
            levelPlayer.start = false;
            //minimapPlayer.start = false;
            Black.gameObject.SetActive(true);
            Gotoselect.gameObject.SetActive(true);
            Gameover.gameObject.SetActive(true);
            speedup.gameObject.SetActive(false);
            timepause = true;
            pitchValue = 0;
            volumeValue = 1;
        }
        else
        {
            return;
        }


    }

    IEnumerator aniPlay()
    {
        yield return new WaitForSecondsRealtime(gear1);
        speedmult = speedmult + 0.2f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup");
        pitchValue = 1.2f;
        Debug.Log("speedup1");

        yield return new WaitForSecondsRealtime(gear2);
        speedmult = speedmult + 0.5f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup2");
        pitchValue = 1.5f;
        Debug.Log("speedup2");

        yield return new WaitForSecondsRealtime(gear3);
        speedmult = speedmult + 0.8f;
        pitchValue = 1.8f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup");
        Debug.Log("speedup3");

        yield return new WaitForSecondsRealtime(gear4);
        speedmult = speedmult + 1.1f;
        pitchValue = 2.1f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup2");
        Debug.Log("speedup4");

        yield return new WaitForSecondsRealtime(gear5);
        speedmult = speedmult + 1.4f;
        pitchValue = 2.4f;
        speedup.gameObject.GetComponent<Animator>().Play("speedup");
        Debug.Log("speedup5");
    }
}
