using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPerpect : MonoBehaviour
{
    public GameObject Collider;
    public GameObject Cool;
    public Transform JudgeLocation;

    // Start is called before the first frame update
    void Start()
    {
        Collider.gameObject.SetActive(true);
    }
}
