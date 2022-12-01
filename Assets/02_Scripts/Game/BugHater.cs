using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugHater : MonoBehaviour
{
    public GameObject Coll;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Coll.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject);

        }
    }
}
