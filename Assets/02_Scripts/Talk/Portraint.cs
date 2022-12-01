using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portraint : MonoBehaviour
{
    public Sprite Normal;
    public Sprite Happy;
    public Sprite Angry;
    public Sprite Love;
    public Sprite Fun;
    public Sprite Special;
    public Sprite Dark;
    public Sprite Add;
    public Sprite Addtwo;
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Judgement.instance.emotion == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = Normal;
        }
        if (Judgement.instance.emotion == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = Happy;
        }
        else if (Judgement.instance.emotion == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = Angry;
        }
        else if (Judgement.instance.emotion == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = Love;
        }
        else if (Judgement.instance.emotion == 4)
        {
            this.gameObject.GetComponent<Image>().sprite = Fun;
        }
        else if (Judgement.instance.emotion == 5)
        {
            this.gameObject.GetComponent<Image>().sprite = Special;
        }
        else if (Judgement.instance.emotion == 6)
        {
            this.gameObject.GetComponent<Image>().sprite = Dark;
        }
        else if (Judgement.instance.emotion == 7)
        {
            this.gameObject.GetComponent<Image>().sprite = Add;
        }
        else if (Judgement.instance.emotion == 8)
        {
            this.gameObject.GetComponent<Image>().sprite = Addtwo;
        }
        else
            this.gameObject.GetComponent<Image>().sprite = Normal;
    }
}
