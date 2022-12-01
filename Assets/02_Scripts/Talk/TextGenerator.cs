using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerator : MonoBehaviour
{
    public Text exittext;
    public int talknumber;
    private string strings;
    // Start is called before the first frame update
    void Start()
    {
        strings = LocalizingManager.Instance.GetValue(talknumber.ToString());
        exittext.text = strings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
