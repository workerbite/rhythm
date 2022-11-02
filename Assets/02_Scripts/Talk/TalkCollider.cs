using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCollider : MonoBehaviour
{
    public int TalkNumber;
    public int EmoNumber;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("me too");
            Judgement.instance.GetTalkNumber = TalkNumber;
            Judgement.instance.emotion = EmoNumber;
            Destroy(gameObject);
        }

    }
}
