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
    private bool IsJumping;   //���� ���ɻ��� 
    private float IsJumpTime; //��Ÿ���� ���� ������ �ð�
    bool Ground;              //���� ¤���ִ��� �˻�.
    private bool DBJumping;   //�������� ���ɻ���
    private bool Jumpkill;    //�÷��� ����� ���
    public float JumpCoolDown;  //���� ������ ���� ��Ÿ��

    //������ ����
    private bool IsAttacking;   //���� ���ɻ���
    private float IsAttackTime; //��Ÿ�ӿ� ���ݽð� �˻�
    private bool DBAttacking;   //������� ���ɻ���
    private float IsDamageTime; //�������� ���� üũ�ڽ� �ߵ��ð� �˻�
    private float BDDamageTime; //����������� ���� üũ�ڽ� �ߵ��ð� �˻�
    public GameObject Coll;     //���� üũ�ڽ�
    public GameObject Coll2;    //������� üũ�ڽ�


    //������ ����
    private bool IsDodging;   //ȸ�� ���ɻ���
    private float IsDodgeTime; //��Ÿ�ӿ� ȸ�ǽð� �˻�
    private bool DBDodging;   //����ȸ�� ���ɻ���
    private float IsMissTime; //ȸ�Ƿ� ���� üũ�ڽ� �ߵ��ð� �˻�
    private float BDMissTime; //����ȸ�Ƿ� ���� üũ�ڽ� �ߵ��ð� �˻�
    public GameObject Doll;     //ȸ�� üũ�ڽ�
    public GameObject Doll2;    //����ȸ�� üũ�ڽ�


    //������� ����
    public bool Damaging;

    //���带 ����

    private AudioSource audiofx;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    public AudioClip dodgeSound;

    //ī�޶� ������ ����

    Vector2 pos;


    void Awake()
    {

        life = GameObject.Find("CharacterInfo").GetComponent<CharacterInfo>();
        mainSys = GameObject.Find("GameSystem").GetComponent<MainSys>();

    }

    void Start()
    {
        //�׽�Ʈ�� ����� �⺻���� ��� �ƴ����� ó��
        Damaging = false;
        //���� ����� ���� (�̰� �ٲ�� ��)
        this.audiofx = GetComponent<AudioSource>();
        //���۽� ��� ���� �����ϵ��� 
        IsJumping = true;
        DBJumping = false;
        Jumpkill = false;
        JumpCoolDown = 0.1f;
        //������ ���� �Ұ� �� ����
        IsAttacking = true;
        DBAttacking = true;
        Ground = true;
        //������ �������� �� ����
        Coll.gameObject.SetActive(false);
        Coll2.gameObject.SetActive(false);
        //������ ȸ�� �Ұ� �� ����
        IsDodging = true;
        DBDodging = true;
        //������ ȸ������ �� ����
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
        //�ൿ�Ұ��� ����ų�� ������ ������ �ش� ��ġ�� �ڵ��������ֱ� ���.
        if (Jumpkill == false) //����ų�� ����������
        {
            if (gameObject.transform.position != new Vector3(-7f, 0, 0)) //�׸��� x��ǥ�� �������(��ֹ��� ���� �з����ų�) 
            {
                transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(mainSys.StartPosition, transform.position.y, transform.position.z), 0.1f);
                //��� x��ǥ�� Ÿ����x��ǥ��. ��� y��ǥ�� z��ǥ�� �״�� �ΰ� transform.position.y�� �ƹ��͵� �̵������� �ʰ� ��ĭ ä�ﶧ ���� ���
            }
            else
            {
                return; //�ƴϸ� ���������� �ٽ���
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
        /////////////���� ���
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.C))  //��Ŭ����(���� Ư�� ��ư���� ��ü����)
        {
            if (IsAttacking == true)   //���� ������ Ǯ�ȴٸ�
            {
                Coll.gameObject.SetActive(true); //���ݹ��� Ȱ��ȭ
                IsAttackTime = Time.fixedTime;   //���ݽð� ���
                IsDamageTime = Time.fixedTime;   //���ƹ��� �ߵ��ð� ���
                IsAttacking = false; //���� ������ ����
                if (IsJumping == false) //�����Ұ����� = �������� ��� !IsJumping
                {
                    gameObject.GetComponent<Animator>().Play("Aattack1");
                    PlaySound("Attack");
                }
                else //������ �ƴ϶�� ������� ���
                {
                    gameObject.GetComponent<Animator>().Play("attack1");
                    PlaySound("Attack");
                }
            }
            else if (DBAttacking == true) //�� ��������� ������������ �׳������� ��, !DBAttacking������ ������ �����̶�� ���̴�)
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
        /////////////ȸ�Ǳ��
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z)) //��Ŭ����(���� Ư�� ��ư���� ��ü����)
        {
            if (IsDodging == true)   //ȸ�� ������ Ǯ�ȴٸ�
            {
                Doll.gameObject.SetActive(true); //ȸ�ǹ��� Ȱ��ȭ
                IsDodgeTime = Time.fixedTime;   //ȸ�ǽð� ���
                IsMissTime = Time.fixedTime;   //ȸ�ǹ��� �ߵ��ð� ���
                IsDodging = false; //���� ȸ�Ǵ� ����
                if (IsJumping == false) //�����Ұ����� = �������� ��� !IsJumping
                {
                    gameObject.GetComponent<Animator>().Play("Ddodge1");
                    PlaySound("Dodge");
                }
                else //������ �ƴ϶�� ����ȸ�� ���
                {
                    gameObject.GetComponent<Animator>().Play("dodge1");
                    PlaySound("Dodge");
                }

            }
            else if (DBDodging == true) //�� ��������� ������������ �׳������� ��, !DBAttacking������ ������ �����̶�� ���̴�)
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

        ////////////////�������
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.X))
        //if(input.touchCount == 1)
        {
            if (IsJumping == true)//IsJumping==false�� !IsJumping ��¸��� ����. 
            //IsJumping�� ������� �ƴ��� Ȯ�ιް� IsJumping�� �ߵ��� ����,���� ���Ѱ� ���ÿ� ���Ǹ� ������ �ٷ� ����.
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
            else if (DBJumping) //���������� ���
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
