using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject BGroundA;
    public GameObject BGroundB;
    public GameObject BGroundC;
    // Start is called before the first frame update

    void Awake()
    {
        BGroundA.gameObject.SetActive(false);
        BGroundB.gameObject.SetActive(false);
        BGroundC.gameObject.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Judgement.instance.bgstage == 0)
            BGroundA.gameObject.SetActive(true);
        else if (Judgement.instance.bgstage == 1)
            BGroundB.gameObject.SetActive(true);
        else if (Judgement.instance.bgstage == 2)
            BGroundC.gameObject.SetActive(true);
    }
}
