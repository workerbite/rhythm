using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacklocation : MonoBehaviour
{

    public GameObject Collider;
    public GameObject Cool;
    public Transform JudgeLocation;


    // Start is called before the first frame update

    void Start()
    {
        Collider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Judgement.instance.thiscool == true)
        {
            StartCoroutine("toCool");
        }

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {                            
            StartCoroutine("CoolDown");
        }
    }
    IEnumerator toCool()
    {
        Instantiate(Cool, JudgeLocation.position, JudgeLocation.rotation);
        yield return new WaitForSecondsRealtime(0.2f);
        Debug.Log("Cool");
    }

    IEnumerator CoolDown()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);

    }
}
