using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutora : MonoBehaviour
{
    public GameObject Cooll;     //공격 체크박스
    public GameObject Dooll;     //회피 체크박스

    void Awake()
    {
        Cooll.gameObject.SetActive(false);
        Dooll.gameObject.SetActive(false);
    }

    void Start()
    {
        //시작전 회피판정 다 끄기
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.C))  //우클릭시(추후 특정 버튼으로 교체예정)
        {
            
            StartCoroutine("Zttack");
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))  //우클릭시(추후 특정 버튼으로 교체예정)
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
        Dooll.gameObject.SetActive(true); //공격범위 활성화
        yield return new WaitForSecondsRealtime(0.5f);
        Dooll.gameObject.SetActive(false);

    }

    IEnumerator RedOk()
    {
        Debug.Log("레드, 성공적이군");
        yield return new WaitForSecondsRealtime(0.5f);
    }

    IEnumerator BlueOk()
    {
        Debug.Log("블루, 성공적이군");
        yield return new WaitForSecondsRealtime(0.5f);
    }

}
