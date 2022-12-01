using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutora : MonoBehaviour
{
    public GameObject Cooll;     //���� üũ�ڽ�
    public GameObject Dooll;     //ȸ�� üũ�ڽ�

    void Awake()
    {
        Cooll.gameObject.SetActive(false);
        Dooll.gameObject.SetActive(false);
    }

    void Start()
    {
        //������ ȸ������ �� ����
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.C))  //��Ŭ����(���� Ư�� ��ư���� ��ü����)
        {
            
            StartCoroutine("Zttack");
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))  //��Ŭ����(���� Ư�� ��ư���� ��ü����)
        {
            
            StartCoroutine("Zodge");
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (Cooll.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine("RedOk");
        }

        if (Dooll.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine("BlueOk");
        }

    }



    IEnumerator Zttack()
    {
        Cooll.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        Cooll.gameObject.SetActive(false);

    }

    IEnumerator Zodge()
    {
        Dooll.gameObject.SetActive(true); //���ݹ��� Ȱ��ȭ
        yield return new WaitForSecondsRealtime(0.5f);
        Dooll.gameObject.SetActive(false);

    }

    IEnumerator RedOk()
    {
        Debug.Log("����, �������̱�");
        yield return new WaitForSecondsRealtime(0.5f);
    }

    IEnumerator BlueOk()
    {
        Debug.Log("���, �������̱�");
        yield return new WaitForSecondsRealtime(0.5f);
    }

}
