using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{

    public GameObject CharaSelect;

    // Start is called before the first frame update
    void Start()
    {
        if (CharaMgr.instance.HaveTutorial == 0)
        {
            Debug.Log("opencharaselect");
            CharaSelect.gameObject.SetActive(true);
        }

        else
        {
            Debug.Log("skipcharaselect");
            SceneManager.LoadScene(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
