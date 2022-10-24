using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //id = 1000 : Talia
        talkData.Add(1000, new string[] { "�ȳ�", "�� ���� ó�� �Ա���?" });
        //id = 100 : Ż���ư� �����ִ� Prision
        talkData.Add(100, new string[] { "��� ������� �����̴�.", "������̴� �� �� ���� �� ����." });
        //id = 200 : ���� ���������� �Ѿ �� �ִ� �� 
        talkData.Add(200, new string[] { "����� ���̴�. \n�� �� ���� �� ����" });
    }

    public string GetTalk(int id, int talkIndex) //Object�� id , string�迭�� index
    {
        return talkData[id][talkIndex]; //�ش� ���̵��� �ش�
    }
}