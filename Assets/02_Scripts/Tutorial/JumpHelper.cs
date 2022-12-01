using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHelper : MonoBehaviour
{
    public GameObject Finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Judgement.instance.ouch == true)
        {
            StartCoroutine("disablefinish");
        }
    }

    IEnumerator disablefinish()
    {
        Finish.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        Finish.gameObject.SetActive(false);
    }
}
