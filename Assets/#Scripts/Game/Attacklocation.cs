using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Attacklocation : MonoBehaviour
{

    public GameObject Collider;
    public GameObject Cool;
    public GameObject Good;
    public bool isGood;
    public Transform JudgeLocation;


    // Start is called before the first frame update

    void Start()
    {
        Collider.gameObject.SetActive(true);
        isGood = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Judgement.instance.thisgood == true)
        {
            if(Judgement.instance.thiscool == true)
            {
                Instantiate(Cool, JudgeLocation.position, JudgeLocation.rotation);
                Judgement.instance.nowscore += 100;
                Judgement.instance.thiscool = false;
                Judgement.instance.thisgood = false;
            }
            else if (Judgement.instance.thiscool == false)
            {
                Instantiate(Good, JudgeLocation.position, JudgeLocation.rotation);
                Judgement.instance.nowscore += 50;
                Judgement.instance.thiscool = false;
                Judgement.instance.thisgood = false;
            }
        }
        if (Judgement.instance.thiscool == true)
        {
            if (Judgement.instance.thisgood == false)
            {
                Instantiate(Cool, JudgeLocation.position, JudgeLocation.rotation);
                Judgement.instance.nowscore += 100;
                Judgement.instance.thiscool = false;
                Judgement.instance.thisgood = false;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            Debug.Log("Good");
            Judgement.instance.thisgood = true;
            //Judgement.instance.nowscore += 1;
            //Instantiate(Good, JudgeLocation.position, JudgeLocation.rotation);
        }
    }

}
