using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkBox : MonoBehaviour
{
    CharacterInfo chanumber;
    public Collider coll;
    public Text exitText;
    public GameObject TextBox;
    private string Talk;
    // Start is called before the first frame update

    void Start()
    {
        chanumber = GameObject.Find("CharacterInfo").GetComponent<CharacterInfo>();
        Judgement.instance.GetTalkNumber = 0;
        Judgement.instance.TotalTalkNumber = 0;
        Judgement.instance.TalkClose = false;
        Judgement.instance.TalkDisable = false;
    }
    private void Update()
    {
        if (Judgement.instance.TalkDisable == true)
        {
            StartCoroutine("Disable");
        }
        if (Judgement.instance.TalkClose == true)
        {
            StartCoroutine("Close");
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("TalkCollider"))
        {

            TextBox.gameObject.SetActive(true);
            StartCoroutine("StartTalk");
            Debug.Log("¥ÎªÁ√¢ √∆¥Ÿ");
            

        }           
    }
    IEnumerator StartTalk()
    {
        
        yield return new WaitForSecondsRealtime(0.1f);
        TextBox.gameObject.GetComponent<Animator>().Play("dialogpop");
        Judgement.instance.TotalTalkNumber = chanumber.charanumber + Judgement.instance.GetTalkNumber;
        Talk = LocalizingManager.Instance.GetValue(Judgement.instance.TotalTalkNumber.ToString());       
        exitText.text = Talk;
        yield return new WaitForSecondsRealtime(1.0f);
        Judgement.instance.GetTalkNumber = 0;
        Judgement.instance.TotalTalkNumber = 0;
    }

    IEnumerator Close()
    {
        yield return new WaitForEndOfFrame();
        TextBox.gameObject.GetComponent<Animator>().Play("dialogclose");
        Judgement.instance.TalkClose = false;
    }

    IEnumerator Disable()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        TextBox.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        exitText.text = "";
        Judgement.instance.TalkDisable = false;
    }

}
