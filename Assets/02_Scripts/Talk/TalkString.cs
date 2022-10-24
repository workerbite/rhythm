using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkString : MonoBehaviour
{

    public static TalkString instance;
    Dictionary<int, string[]> talkData;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�̰��� �׽�Ʈ ��翩", "�θ��� �������� Ȯ���غ���?" });
        talkData.Add(2000, new string[] { "�ٸ� ĳ���ͳ� Ȥ�� �ٸ� �ο����� ����� ��� �׽�Ʈ", "�̰��� �� �ǰ� �ֽ��ϱ�??" });
    }

    public string GetTalk(int id, int talkIndex)
    {

        return talkData[id][talkIndex];

    }
}
