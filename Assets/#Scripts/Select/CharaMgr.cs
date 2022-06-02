using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character //선택 캐릭터명 변수를 열거형으로 정리했다 열거형명 "Character"
{

    Chara_1, Chara_2, Chara_3

}

public class CharaMgr : MonoBehaviour
{
    public static CharaMgr instance; //싱글톤 선언



    private void Awake() //(*싱글톤)private로 시작하며 다룰수 있는 객체는 한개. 다른곳에서 생성하지 못하고 이곳에서만 다루게 된다.
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject); //스크립트가 씬을 넘나들어도 파괴되지 않는다.
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
    public Character currentCharacter; //외부 스크립트 양도용으로 변수명을 선언했다.



}
