using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgedie : MonoBehaviour
{
    public GameObject Collider;
    public GameObject Bomb;


    void Start()
    {
        Collider.gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("dodgeidle");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dodging"))
        {
            gameObject.GetComponent<Animator>().Play("dodgedie");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Destroy");
            Judgement.instance.nowscore += 50;
        }

        if (other.gameObject.CompareTag("DodgingPer"))
        {
            gameObject.GetComponent<Animator>().Play("dodgedie");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Destroy");
            Judgement.instance.nowscore += 50;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().Play("dodgeattack");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            Bomb.gameObject.SetActive(true);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(transform.parent.gameObject);
    }
}
