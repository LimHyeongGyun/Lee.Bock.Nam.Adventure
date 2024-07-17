using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Cobra : Enemy
{
    public GameObject breath;
    public GameObject spawner;

    public Transform shotpos;
    public Transform breathpos;

    public bool isShot;
    public bool isSummons;
    public bool isBreath;
    public bool isact;

    Vector3 lookVec;
    bool isLook; //공격할 때 보던방향 바라보도록

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        SphereCollider = GetComponent<SphereCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        StartCoroutine(ChaseStart());
    }


    protected override void Update()
    {
        base.Update();
        spawner.transform.position = this.transform.position;
        if (isLook)
        {
            //플레이어의 움직임을 예측하기 위해서 플레이어의 입력값을 사용
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            //플레이어 입력값으로 예측 벡터값을 만들어 5를 더함
            lookVec = new Vector3(h, 0, v) * 5f;
            transform.LookAt(target.position + lookVec);
        }
        if (isAttack == true && isact != true)
        {
            isact = true;
            StartCoroutine(Pattern());
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        targetRadius = 1.5f;
        targetRange = 15f;
    }

    IEnumerator Pattern()
    {
        nav.enabled = false;
        int ranAction = Random.Range(0, 3);
        yield return new WaitForSeconds(0.1f);
        switch (ranAction)
        {
            case 0:
                isShot = true;
                yield return StartCoroutine(Shot());
                break;
            case 1:
                isSummons = true;
                yield return StartCoroutine(Summons());
                break;
            case 2:
                isBreath = true;
                yield return StartCoroutine(Breath());
                break;
        }
        nav.enabled = true;
        isact = false;
    }

    IEnumerator Shot()
    {
        isShot = true;
        anim.SetBool("isShot", true);//공격동작
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isShot", false);
        anim.SetBool("isStand", true);
        GameObject instantBullet = Instantiate(bullet, shotpos.position, shotpos.rotation);
        Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
        rigidBullet.velocity = transform.forward * 30;
        anim.SetBool("isStand",false);

        isShot = false;
    }
    IEnumerator Summons()
    {
        isSummons = true;
        anim.SetBool("isSummons", true);
        var delay = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(delay);

        if (isSummons == true)
        {
            for (int i = 0; i < 2; i++)
            {
                Spawn();
            }
        }
        anim.SetBool("isSummons", false);
        isSummons = false;
    }
    public IEnumerator Breath()
    {
        isBreath = true;
        var delay = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        anim.SetBool("isBreath", true);
        yield return new WaitForSeconds(delay);

        anim.SetBool("isBreath", false);
        isBreath = false;
    }

    public IEnumerator BreathFire()
    {
        for (int i = 0; i < 17; i++)
        {
            GameObject instantBreath = Instantiate(breath, breathpos.position, breathpos.rotation);
            Rigidbody rigidBreath = instantBreath.GetComponent<Rigidbody>();
            rigidBreath.velocity = transform.forward * 20;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        enemy.transform.position = target.transform.position;
    }
}