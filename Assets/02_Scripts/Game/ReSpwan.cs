using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpwan : MonoBehaviour
{
    public GameObject[] charPrefabs; //�÷��̾ ������� �� ������.
    public GameObject player; //charprefabs���� ��� �� �� ������.

    void Start()
    {
        player = Instantiate(charPrefabs[(int)CharaMgr.instance.currentCharacter]); //�ν���Ʈ�� ������Ʈ(������) ��ȯ�ϰ� �� ������ player�ȿ� ��´�
        player.transform.position = transform.position; //�÷��̾��� ��ġ�� ������Ʈ ��ġ�� ������
        //�ν��Ͻ��� ������ ������Ʈ�� ��ġ ������ ���־�� �Ѵ� �ϴ� �̰� ������ �� 0.0.0���� ��ȯ�Ǿ���

    }

}
