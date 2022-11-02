using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkClose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dialog close");
            
            StartCoroutine("Close");
            
            
        }

    }

    IEnumerator Close()
    {
        Judgement.instance.TalkClose = true;
        yield return new WaitForSecondsRealtime(0.2f);
        Judgement.instance.TalkDisable = true;
        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(gameObject);
    }

}
