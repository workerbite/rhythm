using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimapplayer : MonoBehaviour
{

    public float TT;
    public bool start;
    private float BPS;
    private float BPMM;
    public float BPM;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition = new Vector3(0, -4, 0);
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        BPS = Time.deltaTime * -9f;
        BPMM = 0.0166666666666667f * BPS;
        TT += Time.deltaTime * 1;
        levelmove();

    }

    public void levelmove()
    {
        if (start == true)
        {
            gameObject.transform.localPosition += new Vector3(BPMM * BPM * (0.1f), 0, 0);
        }
        else
        {
            return;
        }

    }
}
