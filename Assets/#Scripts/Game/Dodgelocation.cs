using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgelocation : MonoBehaviour
{

    public GameObject Collider;


    // Start is called before the first frame update

    void Start()
    {
        Collider.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dodge"))
        {
            Destroy(other.gameObject);
            Debug.Log("Dodge");
        }
    }
}
