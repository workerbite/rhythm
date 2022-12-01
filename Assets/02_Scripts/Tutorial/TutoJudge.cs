using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoJudge : MonoBehaviour
{

    public GameObject Click;
    public GameObject Success;
    public GameObject Fail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Judgement.instance.thiscool == true || Judgement.instance.thisgood == true || Judgement.instance.thisdcool || Judgement.instance.thisdgood == true)
        {
            StartCoroutine("opensuccess");
        }

        if (Judgement.instance.jumpsuccess == true)
        {
                StartCoroutine("theopensuccess");
        }

        if (Judgement.instance.ouch == true)
        {
            StartCoroutine("openfail");
        }
    }

    IEnumerator opensuccess()
    {
        Click.gameObject.SetActive(false);
        Success.gameObject.SetActive(true);
        Fail.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        Click.gameObject.SetActive(true);
        Success.gameObject.SetActive(false);
        Fail.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator openfail()
    {
        Click.gameObject.SetActive(false);
        Success.gameObject.SetActive(false);
        Fail.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        Click.gameObject.SetActive(true);
        Success.gameObject.SetActive(false);
        Fail.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator theopensuccess()
    {
        yield return new WaitForSeconds(0.5f);

            Click.gameObject.SetActive(false);
            Success.gameObject.SetActive(true);
            Fail.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(0.5f);
            Click.gameObject.SetActive(true);
            Success.gameObject.SetActive(false);
            Fail.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

    }
}
