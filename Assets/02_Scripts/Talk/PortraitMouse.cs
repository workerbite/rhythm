using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortraitMouse : MonoBehaviour
{
    public Sprite Mu;
    public Sprite Hi;
    public Sprite No;
    public Sprite Ae;
    public Sprite Lak;
    public Sprite Tuk;
    public Sprite Huk;
    public Sprite Chu;
    public Sprite Chutwo;
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Judgement.instance.mouse == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = Mu;
        }
        if (Judgement.instance.mouse == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = Hi;
        }
        else if (Judgement.instance.mouse == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = No;
        }
        else if (Judgement.instance.mouse == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = Ae;
        }
        else if (Judgement.instance.mouse == 4)
        {
            this.gameObject.GetComponent<Image>().sprite = Lak;
        }
        else if (Judgement.instance.mouse == 5)
        {
            this.gameObject.GetComponent<Image>().sprite = Tuk;
        }
        else if (Judgement.instance.mouse == 6)
        {
            this.gameObject.GetComponent<Image>().sprite = Huk;
        }
        else if (Judgement.instance.mouse == 7)
        {
            this.gameObject.GetComponent<Image>().sprite = Chu;
        }
        else if (Judgement.instance.mouse == 8)
        {
            this.gameObject.GetComponent<Image>().sprite = Chutwo;
        }
        else
            this.gameObject.GetComponent<Image>().sprite = Mu;
    }
}
