using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dodgelocation : MonoBehaviour
{

    public GameObject Collider;
    public GameObject dCool;
    //public GameObject dGood;
    public bool isdGood;
    public Transform JudgeLocation;


    // Start is called before the first frame update

    void Start()
    {
        Collider.gameObject.SetActive(true);
        isdGood = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Judgement.instance.thisdcool == true)
        {
            if (Judgement.instance.thisdgood == true || Judgement.instance.thisdgood == false)
            {
                StartCoroutine(Touch());
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Dodge"))
        {           
            Judgement.instance.thisgood = true;
            Debug.Log("dGood");
        }
    }
    IEnumerator Touch()
    {
        Instantiate(dCool, JudgeLocation.position, JudgeLocation.rotation);
        Judgement.instance.nowscore += 50;
        Judgement.instance.thisdcool = false;
        Judgement.instance.thisdgood = false;
        yield return new WaitForSecondsRealtime(0.2f);
    }
}


