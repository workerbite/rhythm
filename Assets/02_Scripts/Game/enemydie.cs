using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydie : MonoBehaviour
{
    public GameObject Collider;
    Vector2 pos;


    void Start()
    {
        Collider.gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("enemyidle");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {            
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            pos = this.gameObject.transform.position;           
            StartCoroutine("Judge");
            gameObject.GetComponent<Animator>().Play("enemydie");
            Debug.Log(pos.x);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().Play("enemyattack");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }



    IEnumerator Judge()
    {
        if (pos.x >= -5.0f - Judgement.instance.bonusjudge && pos.x <= -4.0f + Judgement.instance.bonusjudge)
        {
            Judgement.instance.thiscool = true;
            Judgement.instance.nowscore += 100;
        }
        else
        {
            Judgement.instance.thisgood = true;
            Judgement.instance.nowscore += 50;
        }
        yield return new WaitForEndOfFrame();
        Judgement.instance.thiscool = false;
        Judgement.instance.thisgood = false;

    }
}
