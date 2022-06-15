using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character; //자신의 캐릭터가 어떤건지 지정하기 위해
    //Animator anim;  //내부 객체의 애니메이션을 제어하기 위한 선언, 그나저나 public으로 쓸거아니면 private안써도 되는구나
    Image sr; //위와 동일한 스프라이트 옵션 제어용.
    public SelectChar[] chars; //자신클래스로 enum으로 열거한 캐릭터순서대로 제어하기 위한 변수선언
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
        if (CharaMgr.instance.currentCharacter == character) OnSelect(); //자신의 캐릭터정보와 마우스로 누른 캐릭터정보가 일치하면 onselect의 내용실행.
        else OnDeSelect(); //아님 ondeselect내용 실행
    }

    private void CharaClick()
    {
        CharaMgr.instance.currentCharacter = character; //마우스로 누른 개체는 위의 캐릭터 지정체의 개체로 담아주자
        OnSelect();
        for (int i = 0; i < chars.Length; i++) //mgr의 this가 될때까지 for문 실행
        {
            if (chars[i] != this) chars[i].OnDeSelect(); //SelectChar[] 조건에 안맞는것들,즉 선택되지 않은것은 ondeselect로 실행
        }

    }

    void OnDeSelect()
    {
        //anim.SetBool("jump", false);  //선택 안받은건 애니 재생 안하고
        sr.color = new Color(0.4f, 0.4f, 0.4f);  //컬러 어둡게해라
    }

    void OnSelect()
    {
        //anim.SetBool("jump", true);  // 선택되면
        sr.color = new Color(1f, 1f, 1f);  //반대로하자
        Debug.Log("Saved current to 1");
    }


}
