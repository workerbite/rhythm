using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgedie : MonoBehaviour
{
    public GameObject Collider;
    public GameObject Bomb;
    Vector2 pos;
    


    void Start()
    {
        Bomb.gameObject.SetActive(false);
        Collider.gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("dodgeidle");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dodging"))
        {
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            pos = this.gameObject.transform.position;
            StartCoroutine("Judge");
            gameObject.GetComponent<Animator>().Play("dodgedie");
            //Debug.Log(pos.x);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().Play("dodgeattack");
            Collider.gameObject.GetComponent<BoxCollider>().enabled = false;
            Bomb.gameObject.SetActive(true);
        }
    }

    IEnumerator Judge()
    {
        if (pos.x >= -5.0f - Judgement.instance.bonusjudge && pos.x <= -4.0f + Judgement.instance.bonusjudge)
        {
            Judgement.instance.thisdcool = true;
            Judgement.instance.nowscore += 100;
        }
        else
        {
            Judgement.instance.thisdgood = true;
            Judgement.instance.nowscore += 50;
        }
        yield return new WaitForEndOfFrame();
        Judgement.instance.thisdcool = false;
        Judgement.instance.thisdgood = false;
    }


}
