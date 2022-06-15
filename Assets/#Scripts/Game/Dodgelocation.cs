using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dodgelocation : MonoBehaviour
{

    public GameObject Collider;
    public GameObject dCool;
    public GameObject dGood;
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

        if (Judgement.instance.thisdgood == true)
        {
            if (Judgement.instance.thisdcool == true)
            {
                Instantiate(dCool, JudgeLocation.position, JudgeLocation.rotation);
                Judgement.instance.nowscore += 100;
                Judgement.instance.thisdcool = false;
                Judgement.instance.thisdgood = false;
            }
            else if (Judgement.instance.thisdcool == false)
            {
                Instantiate(dGood, JudgeLocation.position, JudgeLocation.rotation);
                Judgement.instance.nowscore += 50;
                Judgement.instance.thisdcool = false;
                Judgement.instance.thisdgood = false;
            }
        }
        if (Judgement.instance.thisdcool == true)
        {
            if (Judgement.instance.thisdgood == false)
            {
                Instantiate(dCool, JudgeLocation.position, JudgeLocation.rotation);
                Judgement.instance.nowscore += 100;
                Judgement.instance.thisdcool = false;
                Judgement.instance.thisdgood = false;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Dodge"))
        {
            //Destroy(other.gameObject);
            Debug.Log("dGood");
            Judgement.instance.thisgood = true;
            //Instantiate(Good, JudgeLocation.position, JudgeLocation.rotation);
        }
    }

}
