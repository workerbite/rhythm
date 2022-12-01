using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RgbOpen : MonoBehaviour
{
    public int index;
    public GameObject Red;
    public GameObject Green;
    public GameObject Blue;

    // Start is called before the first frame update
    void Awake()
    {
        Red.gameObject.SetActive(false);
        Green.gameObject.SetActive(false);
        Blue.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (index == 1)
            {
                Debug.Log("Get Red");
                Red.gameObject.SetActive(true);
            }

            if (index == 2)
            {
                Debug.Log("Get Green");
                Green.gameObject.SetActive(true);
            }

            if (index == 3)
            {
                Debug.Log("Get Blue");
                Blue.gameObject.SetActive(true);
            }

        }

    }
}
