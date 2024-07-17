using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float truncatedLee = Mathf.Round(playerInfo.LeeDamage * 10f) / 10f;
    float truncatedBock = Mathf.Round(playerInfo.BockDamage * 10f) / 10f;
    float truncatedNam = Mathf.Round(playerInfo.NamDamage * 10f) / 10f;

    public enum Type { A, B, C, Boss };
    public Type enemyType;

    public float maxHealth; //�ִ�ü��
    public float curHealth; //����ü��

    protected float targetRadius = 0;
    protected float targetRange = 0;

    public Transform target; //��ǥ��
    public Transform dmgPos; //������text�� ǥ���� ��ġ
    public BoxCollider meleeArea;
    public GameObject EnemyDmgText; //dmg������
    public GameObject bullet; // ���Ÿ� ���� ����ü
    public Transform arrowPos; // ���Ÿ� ���� ����ü ��ġ

    public bool isChase;
    public bool isAttack;

    bool isDamage;

    public Rigidbody rigid;
    public SphereCollider SphereCollider;
    public NavMeshAgent nav;
    public Animator anim;
    public Material mat;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        SphereCollider = GetComponent<SphereCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        if (SceneChangeManager.charactorNum == 2)
        {
            target = GameObject.Find("Lee").transform;
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            target = GameObject.Find("Bock").transform;
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            target = GameObject.Find("Nam").transform;
        }
    }

    public IEnumerator ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
        yield return null;
    }
    protected virtual void Update()
    {

        if (nav.enabled)
        {
            nav.SetDestination(target.position); //������ ��ǥ ��ġ ���� �Լ�
            nav.isStopped = !isChase;
            if (isChase) transform.LookAt(target.position);
        }
    }

    void FreezeVelocity()
    {
        //�������� NavAgent �̵��� �������� �ʵ��� ���� �߰�
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }

    void Targetting()
    {
        switch (enemyType)
        {
            case Type.A: // �ٰŸ� ��ũ
                targetRadius = 1.5f;
                targetRange = 1.5f;
                break;
            case Type.B: // �ٰŸ� ��ġ�����
                targetRadius = 1.0f; //�ӽð�
                targetRange = 5f;
                break;
            case Type.C: // ���Ÿ�����
                targetRadius = 0.5f;
                targetRange = 7f;
                break;
            case Type.Boss:
                break;
        }
        //�ڽ��� ��ġ, ��ü ������,���ư��� ����,�Ÿ�,���
        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player")); 

        if (rayHits.Length > 0 && !isAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        if (enemyType != Type.Boss)
        {
            anim.SetBool("isAttack", true);
        }

        switch (enemyType)
        {
            case Type.A: // �ٰŸ� ��ũ
                yield return new WaitForSeconds(0.8f);

                break;
            case Type.B: // �ٰŸ� ���� ����
                yield return new WaitForSeconds(0.3f);
                rigid.AddForce(transform.forward * 25, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.3f);
                rigid.velocity = Vector3.zero;
                meleeArea.enabled = false;

                yield return new WaitForSeconds(0.1f);
                break;
            case Type.C: // ���Ÿ�����               
                yield return new WaitForSeconds(1f);
                GameObject instantBullet = Instantiate(bullet, arrowPos.position, arrowPos.rotation);
                Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
                rigidBullet.velocity = transform.forward * 30;               
                break;
            case Type.Boss:
                break;
        }

        yield return new WaitForSeconds(0.8f);

        isChase = true;
        isAttack = false;
        if(enemyType != Type.Boss)
            anim.SetBool("isAttack", false);
    }

    protected virtual void FixedUpdate()
    {
        Targetting();
        FreezeVelocity();
    }


    void OnTriggerEnter(Collider other) //�±� �� ����
    {
        //���� ���ݿ� ���� ���Ͱ� �޴� �ǰ� ������

        if(other.tag == "Melee")
        {
            if (!isDamage)
            {
                Weapon weapon = other.GetComponent<Weapon>();
                curHealth -= playerInfo.LeeDamage;
                Vector3 reactVec = transform.position - other.transform.position; //����� ���� �������� �˹�
                Debug.Log(curHealth);

                GameObject enemyText = Instantiate(EnemyDmgText);
                enemyText.transform.position = dmgPos.position;
                enemyText.GetComponent<DamageText>().damage = truncatedLee;
                Debug.Log(playerInfo.LeeDamage);
                StartCoroutine(OnDamage(reactVec, false));
            }
        }
        else if (other.tag == "Arrow")
        {
            if (!isDamage)
            {
                PlayerBullet arrow = other.GetComponent<PlayerBullet>();
                curHealth -= playerInfo.BockDamage;
                Vector3 reactVec = transform.position - other.transform.position; //����� ���� �������� �˹�
                Destroy(other.gameObject); //���� ����� �� �����ǵ��� ȣ��

                GameObject enemyText = Instantiate(EnemyDmgText);
                enemyText.transform.position = dmgPos.position;
                enemyText.GetComponent<DamageText>().damage = truncatedBock;
                Debug.Log(playerInfo.BockDamage);
                StartCoroutine(OnDamage(reactVec, false));
            }
        }
        else if (other.tag == "Fire")
        {
            if (!isDamage)
            {
                PlayerBullet fire = other.GetComponent<PlayerBullet>();
                curHealth -= playerInfo.NamDamage;
                Vector3 reactVec = transform.position - other.transform.position; //����� ���� �������� �˹�
                Destroy(other.gameObject); //���� ����� �� �����ǵ��� ȣ��

                GameObject enemyText = Instantiate(EnemyDmgText);
                enemyText.transform.position = dmgPos.position;
                enemyText.GetComponent<DamageText>().damage = truncatedNam;
                Debug.Log(playerInfo.NamDamage);
                StartCoroutine(OnDamage(reactVec, false));
            }
        }
    }

    public void HitByGrenade(Vector3 explosionPos) // ������ ���� ���������� �Լ�
    {
        curHealth -= playerInfo.NamDamage; // Nam�� ��������ŭ ��������
        Vector3 reactVec = transform.position - explosionPos;
        GameObject enemyText = Instantiate(EnemyDmgText);
        enemyText.transform.position = dmgPos.position;
        enemyText.GetComponent<DamageText>().damage = playerInfo.NamDamage;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)
    {
        isDamage = true;
        mat.color = Color.red; //�ǰݽ� ��

        if (enemyType == Type.Boss)
            yield return null; //ȭ�� ������ ���ÿ� �´°� ����.
        else
        {
            yield return new WaitForSeconds(0.1f);
        }       
        isDamage = false;

        if (curHealth > 0)
        {
            mat.color = new Color(1,1,1); //���Ͱ� ���׾����� ���� ������
        }

        else
        {
            isDamage = true;
            meleeArea.enabled = false;
            mat.color = Color.gray;
            gameObject.layer = 11; //���� ������ �ǰ� X
            isChase = false;
            nav.enabled = false; //������׼� ����
            anim.SetTrigger("doDie");

            if (isGrenade) // ������ ������ �˹��� �� ���ϰ� �ֱ� ���� ����
            {
                reactVec = reactVec.normalized; //�˹� ��ġ�� �ٲ��� �ʰ� ����
                reactVec += Vector3.up * 3;

                rigid.freezeRotation = false;
                rigid.AddForce(reactVec * 5, ForceMode.Impulse); //�˹����� ��������� �������� ��
                rigid.AddTorque(reactVec * 15, ForceMode.Impulse); // ������ ȸ����
            }
            else
            {
                reactVec = reactVec.normalized; 
                reactVec += Vector3.up; 
                rigid.AddForce(reactVec * 5, ForceMode.Impulse); 
            }

            if (enemyType != Type.Boss)
            {
                CheckEnemy.curEnemy -= 1;
            }
            if(enemyType == Type.Boss)
            {
                CheckEnemy.curbossEnemy -= 1;
                GameManager.gameState = State.GameClear;
            }

            yield return new WaitForSeconds(2f);
            if(enemyType != Type.Boss) // ü�¹� ���� �������� ����
            {
                GameObject parent = transform.parent.gameObject;
                parent.SetActive(false);
            }
        }
    }

    void Target()
    {
        if (SceneChangeManager.charactorNum == 2)
        {
            target = GameObject.Find("Lee").transform;
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            target = GameObject.Find("Bock").transform;
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            target = GameObject.Find("Nam").transform;
        }
    }

    void OnEnable()
    {
        if (enemyType != Type.Boss)
        {
            StartCoroutine(ChaseStart());
            Target(); 
            curHealth = maxHealth;

            //false�� ������Ʈ�� true�� �Ǿ��� ��
            isDamage = false;
            meleeArea.enabled = true;
            mat.color = new Color(1, 1, 1);
            gameObject.layer = 10;
            isChase = true;
            nav.enabled = true;
        }
    }
}
