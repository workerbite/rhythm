using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character; //�ڽ��� ĳ���Ͱ� ����� �����ϱ� ����
    Animator anim;  //���� ��ü�� �ִϸ��̼��� �����ϱ� ���� ����, �׳����� public���� ���žƴϸ� private�Ƚᵵ �Ǵ±���
    SpriteRenderer sr; //���� ������ ��������Ʈ �ɼ� �����.
    public SelectChar[] chars; //�ڽ�Ŭ������ enum���� ������ ĳ���ͼ������ �����ϱ� ���� ��������


    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        if (CharaMgr.instance.currentCharacter == character) OnSelect(); //�ڽ��� ĳ���������� ���콺�� ���� ĳ���������� ��ġ�ϸ� onselect�� �������.
        else OnDeSelect(); //�ƴ� ondeselect���� ����
    }

    private void OnMouseUpAsButton()
    {
        CharaMgr.instance.currentCharacter = character; //���콺�� ���� ��ü�� ���� ĳ���� ����ü�� ��ü�� �������
        OnSelect();
        for (int i = 0; i < chars.Length; i++) //mgr�� this�� �ɶ����� for�� ����
        {
            if (chars[i] != this) chars[i].OnDeSelect(); //SelectChar[] ���ǿ� �ȸ´°͵�,�� ���õ��� �������� ondeselect�� ����
        }
        
    }

    void OnDeSelect()
    {
        anim.SetBool("idle", false);  //���� �ȹ����� �ִ� ��� ���ϰ�
        sr.color = new Color(0.4f, 0.4f, 0.4f);  //�÷� ��Ӱ��ض�
    }

    void OnSelect()
    {
        anim.SetBool("idle", true);  // ���õǸ�
        sr.color = new Color(1f, 1f, 1f);  //�ݴ������
        Debug.Log("Saved current to 1");
    }


}