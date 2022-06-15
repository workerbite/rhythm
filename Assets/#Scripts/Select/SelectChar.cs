using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character; //�ڽ��� ĳ���Ͱ� ����� �����ϱ� ����
    //Animator anim;  //���� ��ü�� �ִϸ��̼��� �����ϱ� ���� ����, �׳����� public���� ���žƴϸ� private�Ƚᵵ �Ǵ±���
    Image sr; //���� ������ ��������Ʈ �ɼ� �����.
    public SelectChar[] chars; //�ڽ�Ŭ������ enum���� ������ ĳ���ͼ������ �����ϱ� ���� ��������
    Button btn;


    void Start()
    {
        //anim = GetComponent<Animator>();
        btn = this.transform.GetComponent<Button>();
        if(btn!=null)
        {
            btn.onClick.AddListener(CharaClick);
        }
        sr = GetComponent<Image>();
        if (CharaMgr.instance.currentCharacter == character) OnSelect(); //�ڽ��� ĳ���������� ���콺�� ���� ĳ���������� ��ġ�ϸ� onselect�� �������.
        else OnDeSelect(); //�ƴ� ondeselect���� ����
    }

    private void CharaClick()
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
        //anim.SetBool("jump", false);  //���� �ȹ����� �ִ� ��� ���ϰ�
        sr.color = new Color(0.4f, 0.4f, 0.4f);  //�÷� ��Ӱ��ض�
    }

    void OnSelect()
    {
        //anim.SetBool("jump", true);  // ���õǸ�
        sr.color = new Color(1f, 1f, 1f);  //�ݴ������
        Debug.Log("Saved current to 1");
    }


}
