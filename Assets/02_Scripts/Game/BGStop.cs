using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGStop : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Judgement.instance.bgstop == true)
        {
            anim.GetComponent<Animator>().enabled = false;
        }
    }
}
