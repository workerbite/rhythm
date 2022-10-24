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
        talkData.Add(1000, new string[] { "이것은 테스트 대사여", "두마디도 가능한지 확인해볼까?" });
        talkData.Add(2000, new string[] { "다른 캐릭터나 혹은 다른 부여받은 사람의 대사 테스트", "이것은 잘 되고 있습니까??" });
    }

    public string GetTalk(int id, int talkIndex)
    {

        return talkData[id][talkIndex];

    }
}
