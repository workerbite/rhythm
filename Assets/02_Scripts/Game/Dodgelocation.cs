using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgelocation : MonoBehaviour
{

    public GameObject Collider;
    public GameObject dCool;
    public Transform JudgeLocation;


    // Start is called before the first frame update

    void Start()
    {
        Collider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Judgement.instance.thisdcool == true)
        {
            StartCoroutine("toCool");
        }

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Dodge"))
        {
            StartCoroutine("CoolDown");
        }
    }
    IEnumerator toCool()
    {
        Instantiate(dCool, JudgeLocation.position, JudgeLocation.rotation);
        yield return new WaitForSecondsRealtime(0.2f);
        Debug.Log("dCool");
    }
    IEnumerator CoolDown()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);

    }
}


