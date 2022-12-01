using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    public void StartClick()
    {
        StartCoroutine("blues");

        //LoadingSceneManager.LoadScene(sceneName);
    }

    IEnumerator blues()
    {
        Judgement.instance.Jump = true;
        yield return new WaitForEndOfFrame();
        Judgement.instance.Jump = false;

    }
}
