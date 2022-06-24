using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
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
            StartCoroutine(CameraActive());
            //Ninjafan.gameObject.SetActive(true);
            //Debug.Log("domo ninjadesu");
        }
    }
    IEnumerator CameraActive()
    {
        Judgement.instance.Camera = true;
        yield return new WaitForSecondsRealtime(0.1f);
        Judgement.instance.Camera = false;
    }
}
