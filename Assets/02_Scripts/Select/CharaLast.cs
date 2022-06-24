using UnityEngine;
using UnityEngine.UI;



public class CharaLast : MonoBehaviour
{
    public Character character;
    private int lastcharan;
    private int notchara;

    void Update()
    {
        lastcharan = (int)character;
        character = CharaMgr.instance.currentCharacter;
        transform.GetChild((int)character).gameObject.SetActive(true);
        for (int i = 0; i < transform.childCount; i++)
        {
            notchara = i;
            if (i != lastcharan)
            {
                transform.GetChild(notchara).gameObject.SetActive(false);
            }
        }
    }

}
