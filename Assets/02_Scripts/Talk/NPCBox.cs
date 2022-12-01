using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBox : MonoBehaviour
{
    private int chanumber;
    public Collider coll;
    public Text exitText;
    public GameObject TextBox;
    private string Talk;
    // Start is called before the first frame update

    void Start()
    {
        chanumber = 0;
        Judgement.instance.GetNPCNumber = 0;
        Judgement.instance.TotalNPCNumber = 0;
        Judgement.instance.NPCClose = false;
        Judgement.instance.NPCDisable = false;
    }
    private void Update()
    {
        if (Judgement.instance.NPCDisable == true)
        {
            StartCoroutine("Disable");
        }
        if (Judgement.instance.NPCClose == true)
        {
            StartCoroutine("Close");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("NPCcollider"))
        {

            TextBox.gameObject.SetActive(true);
            StartCoroutine("StartTalk");
            Debug.Log("npc ÃÆ´Ù");


        }
    }
    IEnumerator StartTalk()
    {

        yield return new WaitForSecondsRealtime(0.1f);
        TextBox.gameObject.GetComponent<Animator>().Play("dialogpop");
        Judgement.instance.TotalNPCNumber = chanumber + Judgement.instance.GetNPCNumber;
        Talk = LocalizingManager.Instance.GetValue(Judgement.instance.TotalNPCNumber.ToString());
        exitText.text = Talk;
        yield return new WaitForSecondsRealtime(1.0f);
        Judgement.instance.GetNPCNumber = 0;
        Judgement.instance.TotalNPCNumber = 0;
    }

    IEnumerator Close()
    {
        yield return new WaitForEndOfFrame();
        TextBox.gameObject.GetComponent<Animator>().Play("dialogclose");
        Judgement.instance.NPCClose = false;
    }

    IEnumerator Disable()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        TextBox.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        exitText.text = "";
        Judgement.instance.NPCDisable = false;
    }

}
