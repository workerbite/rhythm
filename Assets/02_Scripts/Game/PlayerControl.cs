using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    CharacterInfo life;
    MainSys mainSys;


    //시스템 보조용
    //public int StartPosition;

    //점프를 위한 
    private bool IsJumping;   //점프 가능상태 
    private float IsJumpTime; //쿨타임을 위한 점프한 시각
    bool Ground;              //땅을 짚고있는지 검사.
    private bool DBJumping;   //더블점프 가능상태
    private bool Jumpkill;    //플레이 제어권 상실
    public float JumpCoolDown;  //제어 가능한 점프 쿨타임

    //공격을 위한
    private bool IsAttacking;   //공격 가능상태
    private float IsAttackTime; //쿨타임용 공격시간 검사
    private bool DBAttacking;   //더블어택 가능상태
    private float IsDamageTime; //공격으로 인한 체크박스 발동시간 검사
    private float BDDamageTime; //더블어택으로 인한 체크박스 발동시간 검사
    public GameObject Coll;     //공격 체크박스
    public GameObject Coll2;    //더블어택 체크박스


    //닷지를 위한
    private bool IsDodging;   //회피 가능상태
    private float IsDodgeTime; //쿨타임용 회피시간 검사
    private bool DBDodging;   //더블회피 가능상태
    private float IsMissTime; //회피로 인한 체크박스 발동시간 검사
    private float BDMissTime; //더블회피로 인한 체크박스 발동시간 검사
    public GameObject Doll;     //회피 체크박스
    public GameObject Doll2;    //더블회피 체크박스


    //생명력을 위한
    public bool Damaging;

    //사운드를 위한

    private AudioSource audiofx;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip dodgeSound;

    //카메라 점프를 위한

    Vector2 pos;


    void Awake()
    {

        life = GameObject.Find("CharacterInfo").GetComponent<CharacterInfo>();
        mainSys = GameObject.Find("GameSystem").GetComponent<MainSys>();

    }

    void Start()
    {
        //테스트용 생명력 기본제공 사망 아님으로 처리
        Damaging = false;
        //사운드 재생기 설정 (이건 바꿔야 함)
        this.audiofx = GetComponent<AudioSource>();
        //시작시 모든 점프 가능하도록 
        IsJumping = true;
        DBJumping = false;
        Jumpkill = false;
        JumpCoolDown = 0.1f;
        //시작전 공격 불가 다 끄기
        IsAttacking = true;
        DBAttacking = true;
        Ground = true;
        //시작전 공격판정 다 끄기
        Coll.gameObject.SetActive(false);
        Coll2.gameObject.SetActive(false);
        //시작전 회피 불가 다 끄기
        IsDodging = true;
        DBDodging = true;
        //시작전 회피판정 다 끄기
        Doll.gameObject.SetActive(false);
        Doll2.gameObject.SetActive(false);
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "Jump":
                audiofx.clip = jumpSound;
                break;

            case "Attack":
                audiofx.clip = attackSound;
                break;

            case "Dodge":
                audiofx.clip = dodgeSound;
                break;
        }

        audiofx.Play();
    }
    void Update()
    {
        //행동불가인 점프킬과 생존시 언제나 해당 위치로 자동정렬해주기 기능.
        if (Jumpkill == false) //점프킬이 꺼져있으면
        {
            if (gameObject.transform.position != new Vector3(-7f, 0, 0)) //그리고 x좌표가 벗어났을때(장애물에 의해 밀려나거나) 
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(mainSys.StartPosition, transform.position.y, transform.position.z), 0.1f);
                //길다 x좌표는 타겟의x좌표로. 대신 y좌표는 z좌표는 그대로 두고 transform.position.y가 아무것도 이동원하지 않고 빈칸 채울때 쓰는 방법
            }
            else
            {
                return; //아니면 맞을때까지 다시해
            }
        }
        if (Jumpkill == true)
        {
            IsJumping = false;
            DBJumping = false;
            IsAttacking = false;
            DBAttacking = false;
            IsDodging = false;
            DBDodging = false;
        }
        /////////////공격 기능
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.C))  //우클릭시(추후 특정 버튼으로 교체예정)
        {
            if (IsAttacking == true)   //어택 금지가 풀렸다면
            {
                Coll.gameObject.SetActive(true); //공격범위 활성화
                IsAttackTime = Time.fixedTime;   //공격시간 기록
                IsDamageTime = Time.fixedTime;   //공걱범위 발동시간 기록
                IsAttacking = false; //이제 어택은 금지
                if (IsJumping == false) //점프불가상태 = 점프상태 고로 !IsJumping
                {
                    gameObject.GetComponent<Animator>().Play("Aattack1");
                    PlaySound("Attack");
                }
                else //공중이 아니라면 지상공격 재생
                {
                    gameObject.GetComponent<Animator>().Play("attack1");
                    PlaySound("Attack");
                }
            }
            else if (DBAttacking == true) //또 적어두지만 참거짓변수를 그냥적으면 참, !DBAttacking식으로 적으면 거짓이라는 말이다)
            {
                DBAttacking = false;
                Coll2.gameObject.SetActive(true);
                BDDamageTime = Time.fixedTime;
                if (IsJumping == true)
                {
                    gameObject.GetComponent<Animator>().Play("Aattack2");
                    PlaySound("Attack");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        if (Time.fixedTime >= IsAttackTime + 0.3f)
        {
            IsAttacking = true;
            DBAttacking = true;

        }
        if (Time.fixedTime >= IsDamageTime + 0.15f)
        {
            Coll.gameObject.SetActive(false);
        }
        if (Time.fixedTime >= BDDamageTime + 0.15f)
        {
            Coll2.gameObject.SetActive(false);
        }
        /////////////회피기능
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z)) //좌클릭시(추후 특정 버튼으로 교체예정)
        {
            if (IsDodging == true)   //회피 금지가 풀렸다면
            {
                Doll.gameObject.SetActive(true); //회피범위 활성화
                IsDodgeTime = Time.fixedTime;   //회피시간 기록
                IsMissTime = Time.fixedTime;   //회피범위 발동시간 기록
                IsDodging = false; //이제 회피는 금지
                if (IsJumping == false) //점프불가상태 = 점프상태 고로 !IsJumping
                {
                    gameObject.GetComponent<Animator>().Play("Ddodge1");
                    PlaySound("Dodge");
                }
                else //공중이 아니라면 지상회피 재생
                {
                    gameObject.GetComponent<Animator>().Play("dodge1");
                    PlaySound("Dodge");
                }

            }
            else if (DBDodging == true) //또 적어두지만 참거짓변수를 그냥적으면 참, !DBAttacking식으로 적으면 거짓이라는 말이다)
            {
                DBDodging = false;
                Doll2.gameObject.SetActive(true);
                BDMissTime = Time.fixedTime;
                if (IsJumping == true)
                {
                    gameObject.GetComponent<Animator>().Play("Ddodge2");
                    PlaySound("Dodge");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

        }


        if (Time.fixedTime >= IsMissTime + 0.8f)
        {
            IsDodging = true;
            DBDodging = true;

        }
        if (Time.fixedTime >= IsMissTime + 0.15f)
        {
            Doll.gameObject.SetActive(false);
        }
        if (Time.fixedTime >= BDMissTime + 0.15f)
        {
            Doll2.gameObject.SetActive(false);
        }

        ////////////////점프기능
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.X))
        //if(input.touchCount == 1)
        {
            if (IsJumping == true)//IsJumping==false는 !IsJumping 라는말과 같다. 
            //IsJumping이 사용중이 아님을 확인받고 IsJumping을 발동할 승인,거절 권한과 동시에 조건만 맞으면 바로 승인.
            {
                IsJumping = false;
                DBJumping = true;
                Ground = false;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
                gameObject.GetComponent<Animator>().Play("jump");
                PlaySound("Jump");
                IsJumpTime = Time.fixedTime;

            }
            else if (DBJumping) //더블점프가 라면
            {
                DBJumping = false;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
                gameObject.GetComponent<Animator>().Play("djump");
                PlaySound("Jump");
            }
            else
            {
                return;
            }
        }
        if (Time.fixedTime >= IsJumpTime + JumpCoolDown)
        {
            if (Ground == true)
            {
                IsJumping = true;
            }

        }
        else
        {
            return;
        }


        if (Judgement.instance.CameraShot == true)
        {

            gameObject.GetComponent<Animator>().Play("cheese");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(3);
            //Application.LoadLevel ("Game");
        }

        if (life.Life == 0)
        {
            if (life.Dead == false)
            {
                Debug.Log("YOUDIED");
                life.Dead = true;
                gameObject.GetComponent<Animator>().Play("die");
                StartCoroutine("Killaction");
                return;
            }

        }

        if (gameObject.transform.position.y <= -12f)
        {
            if (life.Dead == false)
            {
                life.Dead = true;
                Debug.Log("falldown");
            }

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //IsJumping = false;
            Ground = true;
            DBJumping = false;

            if (Damaging == false)
            {
                gameObject.GetComponent<Animator>().Play("idle");
            }
        }
        else
        {
            return;
        }

    }



    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Jumpkill"))
        {
            StartCoroutine("Killaction");
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            //Destroy(other.gameObject);
            Debug.Log("HitTheWall");
            gameObject.GetComponent<Animator>().Play("ouch");
            StartCoroutine("Hurt");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(other.gameObject);
            Debug.Log("HitbyEnemy");
            gameObject.GetComponent<Animator>().Play("ouch"); //곧 맞아죽기 벽에 박고 죽기가 구분될 예정이기 때문                                 
            StartCoroutine("Hurt");
        }

        if (other.gameObject.CompareTag("Dodge"))
        {
            //Destroy(other.gameObject);
            Debug.Log("YOUTRAPED");
            gameObject.GetComponent<Animator>().Play("ouch"); //곧 맞아죽기 벽에 박고 죽기가 구분될 예정이기 때문
            StartCoroutine("Hurt");
        }

        if (other.gameObject.CompareTag("GameController"))
        {
            pos = this.gameObject.transform.position;
            Judgement.instance.Hight = pos.y + 3.0f;
            Debug.Log(pos.y);
        }
    }


    IEnumerator Killaction()
    {
        Jumpkill = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<Animator>().Play("die");
        yield return new WaitForEndOfFrame();
    }

    IEnumerator Hurt()
    {
        Jumpkill = true;
        life.Life = life.Life - 1;
        Damaging = true;
        gameObject.layer = 6;
        yield return new WaitForSecondsRealtime(0.1f);
        gameObject.layer = 31;
        Jumpkill = false;
    }
}
