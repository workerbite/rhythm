using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClose : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("npc Dialog close");

            StartCoroutine("Close");
        }

    }

    IEnumerator Close()
    {
        Judgement.instance.NPCClose = true;
        yield return new WaitForSecondsRealtime(0.2f);
        Judgement.instance.NPCDisable = true;
        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(gameObject);
    }

}