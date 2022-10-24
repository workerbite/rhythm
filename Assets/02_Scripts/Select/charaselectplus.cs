using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charaselectplus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Click()
    {

        Debug.Log("Click!!!");
        CharaMgr.instance.HaveTutorial++;
        Debug.Log("HaveTutorial End");

    }

    public void GetKunoichi()
    {
        CharaMgr.instance.currentCharacter = Character.Chara_1;
        Debug.Log("choose kuno");
    }

    public void GetJageck()
    {
        CharaMgr.instance.currentCharacter = Character.Chara_2;
        Debug.Log("choose jageck");
    }

    public void Getxiepai()
    {
        CharaMgr.instance.currentCharacter = Character.Chara_3;
        Debug.Log("choose xiepai");
    }
}
