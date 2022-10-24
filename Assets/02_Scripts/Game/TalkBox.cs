using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBox : MonoBehaviour
{
    public GameObject TalkCollider;
    public GameObject TextBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TalkTarget"))
        {
            StartCoroutine("OpenTextbox");
            Debug.Log("¸Â­Ÿ´Ù ´ëÈ­Ã¢");
        }
    }
    
    IEnumerator OpenTextbox()
    {
        
        TextBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
    }

}
