using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Attacklocation : MonoBehaviour
{

    public GameObject Collider;
    public GameObject Cool;
    //public GameObject Good;
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

        if (Judgement.instance.thiscool == true)
        {
            if (Judgement.instance.thisgood == true || Judgement.instance.thisgood == false)
            {
                StartCoroutine(Touch());
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Judgement.instance.thisgood = true;           
            Debug.Log("Good");          
        }
    }
    IEnumerator Touch()
    {
        Instantiate(Cool, JudgeLocation.position, JudgeLocation.rotation);
        Judgement.instance.nowscore += 50;
        Judgement.instance.thiscool = false;
        Judgement.instance.thisgood = false;
        yield return new WaitForSecondsRealtime(0.2f);
    }
}
