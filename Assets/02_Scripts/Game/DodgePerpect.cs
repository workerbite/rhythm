using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgePerpect : MonoBehaviour
{
    public GameObject dCollperpect;

    // Start is called before the first frame update
    void Start()
    {
        dCollperpect.gameObject.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dodge"))
        {
            Debug.Log("isCool");
            Judgement.instance.thisdcool = true;
            //Destroy(other.gameObject);
        }
    }
}
