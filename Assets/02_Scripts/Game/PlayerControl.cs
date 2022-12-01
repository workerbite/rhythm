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
    //public bool inputJump = false;
    private bool canJumping;   //점프 가능상태 
    bool Ground;              //땅을 짚고있는지 검사.
    private bool DBJumping;   //더블점프 가능상태
    private bool Jumpkill;    //플레이 제어권 상실
    public float JumpCoolDown;  //제어 가능한 점프 쿨타임

    //공격을 위한
    //public bool inputRight = false;
    private bool canAttacking;   //공격 가능상태
    private bool DBAttacking;   //더블어택 가능상태
    public GameObject Coll;     //공격 체크박스
    public GameObject Coll2;    //더블어택 체크박스


    //닷지를 위한
    //public bool inputLeft = false;
    private bool canDodging;   //회피 가능상태
    private bool DBDodging;   //더블회피 가능상태
    public GameObject Doll;     //회피 체크박스
    public GameObject Doll2;    //더블회피 체크박스


    //생명력을 위한
    public bool Damaging = false;

    //사운드를 위한

    //private AudioSource audiofx;
    //public AudioClip jumpSound;
    //public AudioClip attackSound;
    //public AudioClip dodgeSound;

    //카메라 점프를 위한

    Vector2 pos;


    void Awake()
    {

        life = GameObject.Find("CharacterInfo").GetComponent<CharacterInfo>();
        mainSys = GameObject.Find("GameSystem").GetComponent<MainSys>();

    }

    void Start()
    {
        
        //시작시 모든 점프 가능하도록 
        canJumping = true;
        DBJumping = false;
        Jumpkill = false;
        JumpCoolDown = 0.1f;
        //시작전 공격 불가 다 끄기
        canAttacking = true;
        DBAttacking = false;
        Ground = true;
        //시작전 공격판정 다 끄기
        Coll.gameObject.SetActive(false);
        Coll2.gameObject.SetActive(false);
        //시작전 회피 불가 다 끄기
        canDodging = true;
        DBDodging = false;
        //시작전 회피판정 다 끄기
        Doll.gameObject.SetActive(false);
        Doll2.gameObject.SetActive(false);
    }




    void ACool()
    {
        canAttacking = true; //어택이 가능
        canDodging = true;
    }

    void ADCool()
    {
        DBAttacking = true; //더블어택이 가능
        DBDodging = true;
    }
    void ATtimes()
    {
        Coll.gameObject.SetActive(false);
        Doll.gameObject.SetActive(false);
    }
    void ADtimes()
    {
        Coll2.gameObject.SetActive(false);
        Doll2.gameObject.SetActive(false);
    }

    void Update()
    {       
        //행동불가인 점프킬과 생존시 언제나 해당 위치로 자동정렬해주기 기능.
        if (Jumpkill == false) //점프킬이 꺼져있으면
        {
            if (gameObject.transform.position != new Vector3(mainSys.StartPosition, 0, 0)) //그리고 x좌표가 벗어났을때(장애물에 의해 밀려나거나) 
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(mainSys.StartPosition, transform.position.y, transform.position.z), 0.1f);
                //길다 x좌표는 타겟의x좌표로. 대신 y좌표는 z좌표는 그대로 두고 transform.position.y가 아무것도 이동원하지 않고 빈칸 채울때 쓰는 방법
            }
            else
            {
                return; //아니면 맞을때까지 다시해
            }
        }

        /////////////공격 기능 Input.GetMouseButtonDown(1) || 는 뺌
        if (Input.GetKeyDown(KeyCode.C) || Judgement.instance.Attack == true)  //우클릭시(추후 특정 버튼으로 교체예정)
        {
            
            if (canAttacking == true)   //어택 금지가 풀렸다면
            {
                Coll.gameObject.SetActive(true); //공격범위 활성화
                canAttacking = false; //이제 어택은 금지
                canDodging = false;
                Invoke("ADCool", life.ACool);
                Invoke("ATtimes", life.ATime);
                if (canJumping == false) //점프불가상태 = 점프상태 고로 !canJumping
                {
                    gameObject.GetComponent<Animator>().Play("Aattack1");
                    Judgement.instance.AttackSound = true;
                }
                else //공중이 아니라면 지상공격 재생
                {
                    gameObject.GetComponent<Animator>().Play("attack1");
                    Judgement.instance.AttackSound = true;
                }
                //StartCoroutine("AttackCoolDown");
            }
            else if (DBAttacking == true) //또 적어두지만 참거짓변수를 그냥적으면 참, !DBAttacking식으로 적으면 거짓이라는 말이다)
            {
                DBAttacking = false;
                DBDodging = false;
                Coll2.gameObject.SetActive(true);
                Invoke("ACool", life.ACool);
                Invoke("ADtimes", life.ATime);
                if (canJumping == true) //점프가 가능하다면 = 플레이어는 땅에있다
                {
                    gameObject.GetComponent<Animator>().Play("attack2");
                    Judgement.instance.AttackSound = true;
                }
                else if (canJumping == false)
                {
                    gameObject.GetComponent<Animator>().Play("Aattack1");
                    Judgement.instance.AttackSound = true;
                }
            }

        }

        /////////////회피기능 (Input.GetMouseButtonDown(0) || 를 뺐음)
        if (Input.GetKeyDown(KeyCode.Z) || Judgement.instance.Dodge == true) //좌클릭시(추후 특정 버튼으로 교체예정)
        {
            if (canDodging == true)   //회피 금지가 풀렸다면
            {
                Doll.gameObject.SetActive(true); //회피범위 활성화
                Invoke("ADCool", life.ACool);
                Invoke("ATtimes", life.ATime);
                canDodging = false; //이제 회피는 금지
                canAttacking = false;
                if (canJumping == false) //점프불가상태 = 점프상태 고로 !canJumping
                {
                    gameObject.GetComponent<Animator>().Play("Ddodge1");
                    Judgement.instance.DodgeSound = true;
                }
                else //공중이 아니라면 지상회피 재생
                {
                    gameObject.GetComponent<Animator>().Play("dodge1");
                    Judgement.instance.DodgeSound = true;
                }

            }
            else if (DBDodging == true) //또 적어두지만 참거짓변수를 그냥적으면 참, !DBAttacking식으로 적으면 거짓이라는 말이다)
            {
                DBDodging = false;
                DBAttacking = false;
                Doll2.gameObject.SetActive(true);
                Invoke("ACool", life.ACool);
                Invoke("ADtimes", life.ATime);
                if (canJumping == true)
                {
                    gameObject.GetComponent<Animator>().Play("dodge2");
                    Judgement.instance.DodgeSound = true;
                }
                else if (canJumping == false)
                {
                    gameObject.GetComponent<Animator>().Play("Ddodge2");
                    Judgement.instance.DodgeSound = true;
                }
            }

        }


        ////////////////점프기능 Input.GetMouseButtonDown(2) || 마우스 기능은 뺌
        if (Input.GetKeyDown(KeyCode.X) || Judgement.instance.Jump == true)
        {
            if (canJumping == true)//canJumping==false는 !canJumping 라는말과 같다. 
            //canJumping이 사용중이 아님을 확인받고 canJumping을 발동할 승인,거절 권한과 동시에 조건만 맞으면 바로 승인.
            {
                canJumping = false;
                DBJumping = true;
                Ground = false;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
                gameObject.GetComponent<Animator>().Play("jump");
                Judgement.instance.JumpSound = true;
                //IsJumpTime = Time.fixedTime;

            }
            else if (DBJumping) //더블점프가 라면
            {
                DBJumping = false;
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().AddForce(0, 1000, 0);
                gameObject.GetComponent<Animator>().Play("djump");
                Judgement.instance.JumpSound = true;
            }
            else
            {
                return;
            }
        }

        if (Ground == true)
        {
            canJumping = true;
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
                gameObject.GetComponent<Rigidbody>().AddForce(0, 600, 0);
                StartCoroutine("Killaction");               
                Jumpkill = true;
                PlayJumpKill();
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
            //canJumping = false;
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


    void PlayJumpKill()
    {
        if (Jumpkill == true) //점프킬의 제어권 상실
        {
            canJumping = false;
            DBJumping = false;
            canAttacking = false;
            DBAttacking = false;
            canDodging = false;
            DBDodging = false;
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
            Judgement.instance.Hight = pos.y + 2.5f;
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
        Judgement.instance.ouch = true;
        yield return new WaitForSecondsRealtime(0.05f);
        gameObject.layer = 31;
        Jumpkill = false;
        Judgement.instance.ouch = false;
    }
}
