using UnityEngine;
using UnityEngine.UI;

//튜토리얼은 여기 www.youtube.com/watch?v=3_xHu-JCkl4

public class ModeSelect : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;  
    private int currentMode;

    private void Awake()
    {
        currentMode = PlayerPrefs.GetInt("lastmode", 0);
        SelectMode(currentMode);
        Debug.Log("load" + currentMode);
    }

    private void SelectMode(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }


    public void ChangeMode(int _change)
    {
        currentMode += _change;
        SelectMode(currentMode);
        PlayerPrefs.SetInt("lastmode", currentMode);
        PlayerPrefs.Save();
        Debug.Log(currentMode);
    }

}
