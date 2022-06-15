using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        }

        if (other.gameObject.CompareTag("AttackPer"))
        {
            gameObject.GetComponent<Animator>().Play("enemydie");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("Destroy");
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Destroy(transform.parent.gameObject);
    }
}
