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
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
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
    public int nowscore = 0;
}