using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydie : MonoBehaviour
{
    public GameObject Collider;


    void Start()
    {
        Collider.gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("enemyidle");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            gameObject.GetComponent<Animator>().Play("enemydie");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Destroy");
            Judgement.instance.nowscore += 50;
        }

        if (other.gameObject.CompareTag("AttackPer"))
        {
            gameObject.GetComponent<Animator>().Play("enemydie");
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
