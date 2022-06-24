using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPerpect : MonoBehaviour
{
    public GameObject Collperpect;

    // Start is called before the first frame update
    void Start()
    {
        Collperpect.gameObject.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("isCool");
            Judgement.instance.thiscool = true;
            //Destroy(other.gameObject);
        }
    }
}
