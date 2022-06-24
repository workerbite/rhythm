using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgedie : MonoBehaviour
{
    public GameObject Collider;


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
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(transform.parent.gameObject);
    }
}
