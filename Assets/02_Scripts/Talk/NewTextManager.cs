using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTextManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; //지문 id와 지문 내용을 그룹 저장해두는 기능
    public int id;
    public Text tex;
    private string m_text = "두번째 테스트 진행중이다";


    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //talkData초기화
        GenerateData(); //지문 라이브러리 불러오기
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    void GenerateData()
    {
        //id = 1000 : Talia
        talkData.Add(1000, new string[] { "안녕", "이 곳에 처음 왔구나?" });
        //id = 100 : 탈리아가 갇혀있는 Prision
        talkData.Add(100, new string[] { "쇠로 만들어진 감옥이다.", "열쇠없이는 열 수 없는 것 같다." });
        //id = 200 : 다음 스테이지로 넘어갈 수 있는 문 
        talkData.Add(200, new string[] { "평범한 문이다. 들어갈 수 있을 것 같다" });
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i <= m_text.Length; i++)
        {
            tex.text = m_text.Substring(0, i);

            yield return new WaitForSeconds(0.08f);
        }
    }
}
