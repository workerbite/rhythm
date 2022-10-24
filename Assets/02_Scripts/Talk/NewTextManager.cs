using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTextManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData; //���� id�� ���� ������ �׷� �����صδ� ���
    public int id;
    public Text tex;
    private string m_text = "�ι�° �׽�Ʈ �������̴�";


    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //talkData�ʱ�ȭ
        GenerateData(); //���� ���̺귯�� �ҷ�����
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    void GenerateData()
    {
        //id = 1000 : Talia
        talkData.Add(1000, new string[] { "�ȳ�", "�� ���� ó�� �Ա���?" });
        //id = 100 : Ż���ư� �����ִ� Prision
        talkData.Add(100, new string[] { "��� ������� �����̴�.", "������̴� �� �� ���� �� ����." });
        //id = 200 : ���� ���������� �Ѿ �� �ִ� �� 
        talkData.Add(200, new string[] { "����� ���̴�. �� �� ���� �� ����" });
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
