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

    public float maxHealth; //최대체력
    public float curHealth; //현재체력

    protected float targetRadius = 0;
    protected float targetRange = 0;

    public Transform target; //목표물
    public Transform dmgPos; //데미지text를 표기할 위치
    public BoxCollider meleeArea;
    public GameObject EnemyDmgText; //dmg프리팹
    public GameObject bullet; // 원거리 몬스터 투사체
    public Transform arrowPos; // 원거리 몬스터 투사체 위치

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
            nav.SetDestination(target.position); //도착할 목표 위치 지정 함수
            nav.isStopped = !isChase;
            if (isChase) transform.LookAt(target.position);
        }
    }

    void FreezeVelocity()
    {
        //물리력이 NavAgent 이동을 방해하지 않도록 로직 추가
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
            case Type.A: // 근거리 오크
                targetRadius = 1.5f;
                targetRange = 1.5f;
                break;
            case Type.B: // 근거리 박치기몬스터
                targetRadius = 1.0f; //임시값
                targetRange = 5f;
                break;
            case Type.C: // 원거리몬스터
                targetRadius = 0.5f;
                targetRange = 7f;
                break;
            case Type.Boss:
                break;
        }
        //자신의 위치, 구체 반지름,나아가는 방향,거리,대상
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
            case Type.A: // 근거리 오크
                yield return new WaitForSeconds(0.8f);

                break;
            case Type.B: // 근거리 돌진 몬스터
                yield return new WaitForSeconds(0.3f);
                rigid.AddForce(transform.forward * 25, ForceMode.Impulse);
                meleeArea.enabled = true;

                yield return new WaitForSeconds(0.3f);
                rigid.velocity = Vector3.zero;
                meleeArea.enabled = false;

                yield return new WaitForSeconds(0.1f);
                break;
            case Type.C: // 원거리몬스터               
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


    void OnTriggerEnter(Collider other) //태그 비교 조건
    {
        //공격 성격에 따른 몬스터가 받는 피격 데미지

        if(other.tag == "Melee")
        {
            if (!isDamage)
            {
                Weapon weapon = other.GetComponent<Weapon>();
                curHealth -= playerInfo.LeeDamage;
                Vector3 reactVec = transform.position - other.transform.position; //무기로 맞은 방향으로 넉백
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
                Vector3 reactVec = transform.position - other.transform.position; //무기로 맞은 방향으로 넉백
                Destroy(other.gameObject); //적과 닿았을 때 삭제되도록 호출

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
                Vector3 reactVec = transform.position - other.transform.position; //무기로 맞은 방향으로 넉백
                Destroy(other.gameObject); //적과 닿았을 때 삭제되도록 호출

                GameObject enemyText = Instantiate(EnemyDmgText);
                enemyText.transform.position = dmgPos.position;
                enemyText.GetComponent<DamageText>().damage = truncatedNam;
                Debug.Log(playerInfo.NamDamage);
                StartCoroutine(OnDamage(reactVec, false));
            }
        }
    }

    public void HitByGrenade(Vector3 explosionPos) // 마법사 공격 광역데미지 함수
    {
        curHealth -= playerInfo.NamDamage; // Nam의 데미지만큼 범위공격
        Vector3 reactVec = transform.position - explosionPos;
        GameObject enemyText = Instantiate(EnemyDmgText);
        enemyText.transform.position = dmgPos.position;
        enemyText.GetComponent<DamageText>().damage = playerInfo.NamDamage;
        StartCoroutine(OnDamage(reactVec, true));
    }

    IEnumerator OnDamage(Vector3 reactVec, bool isGrenade)
    {
        isDamage = true;
        mat.color = Color.red; //피격시 색

        if (enemyType == Type.Boss)
            yield return null; //화살 여러개 동시에 맞는거 가능.
        else
        {
            yield return new WaitForSeconds(0.1f);
        }       
        isDamage = false;

        if (curHealth > 0)
        {
            mat.color = new Color(1,1,1); //몬스터가 안죽었으니 원래 색으로
        }

        else
        {
            isDamage = true;
            meleeArea.enabled = false;
            mat.color = Color.gray;
            gameObject.layer = 11; //몬스터 죽은뒤 피격 X
            isChase = false;
            nav.enabled = false; //사망리액션 유지
            anim.SetTrigger("doDie");

            if (isGrenade) // 마법사 공격은 넉백을 더 강하게 주기 위한 조건
            {
                reactVec = reactVec.normalized; //넉백 수치가 바뀌지 않게 고정
                reactVec += Vector3.up * 3;

                rigid.freezeRotation = false;
                rigid.AddForce(reactVec * 5, ForceMode.Impulse); //넉백으로 즉발적으로 가해지는 힘
                rigid.AddTorque(reactVec * 15, ForceMode.Impulse); // 죽을때 회전함
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
            if(enemyType != Type.Boss) // 체력바 같이 꺼지도록 설정
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

            //false된 오브젝트가 true가 되었을 때
            isDamage = false;
            meleeArea.enabled = true;
            mat.color = new Color(1, 1, 1);
            gameObject.layer = 10;
            isChase = true;
            nav.enabled = true;
        }
    }
}
