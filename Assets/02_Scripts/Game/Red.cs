using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public void StartClick()
    {
        StartCoroutine("reds");
        
        //LoadingSceneManager.LoadScene(sceneName);
    }

    IEnumerator reds()
    {
        Judgement.instance.Dodge = true;
        yield return new WaitForEndOfFrame();
        Judgement.instance.Dodge = false;

    }
}
