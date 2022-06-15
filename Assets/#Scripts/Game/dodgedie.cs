using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        }

        if (other.gameObject.CompareTag("DodgingPer"))
        {
            gameObject.GetComponent<Animator>().Play("dodgedie");
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
