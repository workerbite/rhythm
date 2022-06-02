using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character //���� ĳ���͸� ������ ���������� �����ߴ� �������� "Character"
{

    Chara_1, Chara_2, Chara_3

}

public class CharaMgr : MonoBehaviour
{
    public static CharaMgr instance; //�̱��� ����



    private void Awake() //(*�̱���)private�� �����ϸ� �ٷ�� �ִ� ��ü�� �Ѱ�. �ٸ������� �������� ���ϰ� �̰������� �ٷ�� �ȴ�.
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject); //��ũ��Ʈ�� ���� �ѳ��� �ı����� �ʴ´�.
    }

    void OnEnable()
    {
        int type = PlayerPrefs.GetInt("whatchara", 0);
        if (type == 0)
        {
            currentCharacter = Character.Chara_1;
        }
        else if (type == 1)
        {
            currentCharacter = Character.Chara_2;
        }
        else
        {
            currentCharacter = Character.Chara_3;
        }
    }

    void OnDisable()
    {

        PlayerPrefs.SetInt("whatchara", (int)currentCharacter);
        PlayerPrefs.Save();

    }



    void Update()
    {

    }
    public Character currentCharacter; //�ܺ� ��ũ��Ʈ �絵������ �������� �����ߴ�.



}
