using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Songinfo : MonoBehaviour
{

    public static Songinfo instance = null;

    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    void Update()
    {

    }

    //���� ������ ���̵��� �����ϰ� �� ��� ��(����)
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