using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public void StartClick()
    {
        StartCoroutine("greens");

        //LoadingSceneManager.LoadScene(sceneName);
    }

    IEnumerator greens()
    {
        Judgement.instance.Attack = true;
        yield return new WaitForEndOfFrame();
        Judgement.instance.Attack = false;

    }
}
