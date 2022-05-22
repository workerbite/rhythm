using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Attacklocation : MonoBehaviour
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Kill");
        }
    }
}
