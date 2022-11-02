using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHelper : MonoBehaviour
{
    public static TutorialHelper instance = null;


    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }


    }
    void Start()
    {
        
    }

    public bool redopen = false;
    public bool redclickopen = false;
    public bool redsuccessopen = false;
    public bool redfailopen = false;
    public bool greenopen = false;
    public bool greenclickopen = false;
    public bool greensuccessopen = false;
    public bool greenfailopen = false;
    public bool blueopen = false;
    public bool blueclickopen = false;
    public bool bluesuccessopen = false;
    public bool bluefailopen = false;

}
