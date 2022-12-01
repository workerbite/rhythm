using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject white;
    //public GameObject Coll;


    void Start()
    {
        white.gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("getwhite");
            Debug.Log("아군 건드림");
        }
    }

    IEnumerator getwhite()
    {
        white.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(4);

    }
}
