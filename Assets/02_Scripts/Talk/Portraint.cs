using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portraint : MonoBehaviour
{
    public Sprite Normal;
    public Sprite Happy;
    public Sprite Supprise;
    public Sprite Seriouse;
    public Sprite Hurt;
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
            this.gameObject.GetComponent<Image>().sprite = Supprise;
        }
        else if (Judgement.instance.emotion == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = Seriouse;
        }
        else if (Judgement.instance.emotion == 4)
        {
            this.gameObject.GetComponent<Image>().sprite = Hurt;
        }
        else
            this.gameObject.GetComponent<Image>().sprite = Normal;
    }
}
