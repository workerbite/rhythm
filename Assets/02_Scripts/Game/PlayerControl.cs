using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    CharacterInfo life;
    MainSys mainSys;


    //�ý��� ������
    //public int StartPosition;

    //������ ���� 
    //public bool inputJump = false;
    private bool canJumping;   //���� ���ɻ��� 
    bool Ground;              //���� ¤���ִ��� �˻�.
    private bool DBJumping;   //�������� ���ɻ���
    private bool Jumpkill;    //�÷��� ����� ���
    public float JumpCoolDown;  //���� ������ ���� ��Ÿ��

    //������ ����
    //public bool inputRight = false;
    private bool canAttacking;   //���� ���ɻ���
    private bool DBAttacking;   //������� ���ɻ���
    public GameObject Coll;     //���� üũ�ڽ�
    public GameObject Coll2;    //������� üũ�ڽ�


    //������ ����
    //public bool inputLeft = false;
    private bool canDodging;   //ȸ�� ���ɻ���
    private bool DBDodging;   //����ȸ�� ���ɻ���
    public GameObject Doll;     //ȸ�� üũ�ڽ�
    public GameObject Doll2;    //����ȸ�� üũ�ڽ�


    //������� ����
    public bool Damaging = false;

    //���带 ����

    //private AudioSource audiofx;
    //public AudioClip jumpSound;
    //public AudioClip attackSound;
    //public AudioClip dodgeSound;

    //ī�޶� ������ ����

    Vector2 pos;


    void Awake()
    {

        life = GameObject.Find("CharacterInfo").GetComponent<CharacterInfo>();
        mainSys = GameObject.Find("GameSystem").GetComponent<MainSys>();

    }

    void Start()
    {
        
        //���۽� ��� ���� �����ϵ��� 
        canJumping = true;
        DBJumping = false;
        Jumpkill = false;
        JumpCoolDown = 0.1f;
        //������ ���� �Ұ� �� ����
        canAttacking = true;
        DBAttacking = false;
        Ground = true;
        //������ �������� �� ����
        Coll.gameObject.SetActive(false);
        Coll2.gameObject.SetActive(false);
        //������ ȸ�� �Ұ� �� ����
        canDodging = true;
        DBDodging = false;
        //������ ȸ������ �� ����
        Doll.gameObject.SetActive(false);
        Doll2.gameObject.SetActive(false);
    }




    void ACool()
    {
        canAttacking = true; //������ ����
        canDodging = true;
    }

    void ADCool()
    {
        DBAttacking = true; //��������� ����
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
        //�ൿ�Ұ��� ����ų�� ������ ������ �ش� ��ġ�� �ڵ��������ֱ� ���.
        if (Jumpkill == false) //����ų�� ����������
        {
            if (gameObject.transform.position != new Vector3(mainSys.StartPosition, 0, 0)) //�׸��� x��ǥ�� �������(��ֹ��� ���� �з����ų�) 
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(mainSys.StartPosition, transform.position.y, transform.position.z), 0.1f);
                //��� x��ǥ�� Ÿ����x��ǥ��. ��� y��ǥ�� z��ǥ�� �״�� �ΰ� transform.position.y�� �ƹ��͵� �̵������� �ʰ� ��ĭ ä�ﶧ ���� ���
            }
            else
            {
                return; //�ƴϸ� ���������� �ٽ���
            }
        }

        /////////////���� ��� Input.GetMouseButtonDown(1) || �� ��
        if (Input.GetKeyDown(KeyCode.C) || Judgement.instance.Attack == true)  //��Ŭ����(���� Ư�� ��ư���� ��ü����)
        {
            
            if (canAttacking == true)   //���� ������ Ǯ�ȴٸ�
            {
                Coll.gameObject.SetActive(true); //���ݹ��� Ȱ��ȭ
                canAttacking = false; //���� ������ ����
                canDodging = false;
                Invoke("ADCool", life.ACool);
                Invoke("ATtimes", life.ATime);
                if (canJumping == false) //�����Ұ����� = �������� ��� !canJumping
                {
                    gameObject.GetComponent<Animator>().Play("Aattack1");
                    Judgement.instance.AttackSound = true;
                }
                else //������ �ƴ϶�� ������� ���
                {
                    gameObject.GetComponent<Animator>().Play("attack1");
                    Judgement.instance.AttackSound = true;
                }
                //StartCoroutine("AttackCoolDown");
            }
            else if (DBAttacking == true) //�� ��������� ������������ �׳������� ��, !DBAttacking������ ������ �����̶�� ���̴�)
            {
                DBAttacking = false;
                DBDodging = false;
                Coll2.gameObject.SetActive(true);
                Invoke("ACool", life.ACool);
                Invoke("ADtimes", life.ATime);
                if (canJumping == true) //������ �����ϴٸ� = �÷��̾�� �����ִ�
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

        /////////////ȸ�Ǳ�� (Input.GetMouseButtonDown(0) || �� ����)
        if (Input.GetKeyDown(KeyCode.Z) || Judgement.instance.Dodge == true) //��Ŭ����(���� Ư�� ��ư���� ��ü����)
        {
            if (canDodging == true)   //ȸ�� ������ Ǯ�ȴٸ�
            {
                Doll.gameObject.SetActive(true); //ȸ�ǹ��� Ȱ��ȭ
                Invoke("ADCool", life.ACool);
                Invoke("ATtimes", life.ATime);
                canDodging = false; //���� ȸ�Ǵ� ����
                canAttacking = false;
                if (canJumping == false) //�����Ұ����� = �������� ��� !canJumping
                {
                    gameObject.GetComponent<Animator>().Play("Ddodge1");
                    Judgement.instance.DodgeSound = true;
                }
                else //������ �ƴ϶�� ����ȸ�� ���
                {
                    gameObject.GetComponent<Animator>().Play("dodge1");
                    Judgement.instance.DodgeSound = true;
                }

            }
            else if (DBDodging == true) //�� ��������� ������������ �׳������� ��, !DBAttacking������ ������ �����̶�� ���̴�)
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


        ////////////////������� Input.GetMouseButtonDown(2) || ���콺 ����� ��
        if (Input.GetKeyDown(KeyCode.X) || Judgement.instance.Jump == true)
        {
            if (canJumping == true)//canJumping==false�� !canJumping ��¸��� ����. 
            //canJumping�� ������� �ƴ��� Ȯ�ιް� canJumping�� �ߵ��� ����,���� ���Ѱ� ���ÿ� ���Ǹ� ������ �ٷ� ����.
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
            else if (DBJumping) //���������� ���
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
        if (Jumpkill == true) //����ų�� ����� ���
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
            gameObject.GetComponent<Animator>().Play("ouch"); //�� �¾��ױ� ���� �ڰ� �ױⰡ ���е� �����̱� ����                                 
            StartCoroutine("Hurt");
        }

        if (other.gameObject.CompareTag("Dodge"))
        {
            //Destroy(other.gameObject);
            Debug.Log("YOUTRAPED");
            gameObject.GetComponent<Animator>().Play("ouch"); //�� �¾��ױ� ���� �ڰ� �ױⰡ ���е� �����̱� ����
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
