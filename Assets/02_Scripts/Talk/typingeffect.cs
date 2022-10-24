using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typingeffect : MonoBehaviour
{
    public Text tx;
    private string m_text = "¿Í¶ö¤©¶ö¶ö¶ó¶ó¶ó¶ó¶ó¶ó¶ó¶ó¶ó¶ó¶ö";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

IEnumerator _typing()
    {
        yield return new WaitForSeconds(0.1f);
        for(int i =0; i <= m_text.Length; i++)
        {
            tx.text = m_text.Substring(0, i);
            //tx.text = LocalizingManager.Instance.GetValue("1").Substring(0, i);

            yield return new WaitForSeconds(0.08f);
        }
    }
}
