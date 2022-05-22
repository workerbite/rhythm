using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpwan : MonoBehaviour
{
    public GameObject[] charPrefabs; //플레이어를 담기위한 빈 프리팹.
    public GameObject player; //charprefabs까지 담는 더 빈 프리팹.

    void Start()
    {
        player = Instantiate(charPrefabs[(int)CharaMgr.instance.currentCharacter]); //인스턴트로 오브젝트(프리팹) 소환하고 그 정보는 player안에 담는다
        player.transform.position = transform.position; //플레이어의 위치는 오브젝트 위치로 따른다
        //인스턴스로 생성한 오브젝트는 위치 지정을 해주어야 한다 일단 이게 없으면 걍 0.0.0으로 소환되었음

    }

}
