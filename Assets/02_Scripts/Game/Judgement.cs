using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judgement : MonoBehaviour
{

    public static Judgement instance = null;
    public Text Score;

    private void Awake()
    {
        nowscore = 0;
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            //DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    void Update()
    {

        Score.text = nowscore.ToString();

    }

    //���� ������ ���̵��� �����ϰ� �� ��� ��(����)
    public bool thiscool = false;
    public bool thisgood = false;
    public bool thisdcool = false;
    public bool thisdgood = false;
    public bool musicstart = false;
    public bool musicend = false;
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
    public int nowscore = 0;
    public float Hight = 0;
}