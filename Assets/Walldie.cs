using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walldie : MonoBehaviour
{
    public GameObject Collider;


    void Start()
    {
        Collider.gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("wallidle");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().Play("walldie");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Destroy");
        }
        if (other.gameObject.CompareTag("MusicStarter"))
        {
            gameObject.GetComponent<Animator>().Play("walldie");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Destroy");
            Judgement.instance.nowscore += 100;
        }
    }


    IEnumerator Destroy()
    {
        Judgement.instance.jumpsuccess = true;
        yield return new WaitForEndOfFrame();
        Destroy(this.gameObject);
        Judgement.instance.jumpsuccess = false;
    }
}
