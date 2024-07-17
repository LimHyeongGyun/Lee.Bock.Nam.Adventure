using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SalamanderKing : Enemy
{
    public GameObject spit;
    public GameObject comeup;

    public Transform spitpos;
    public Transform[] comeuppos;

    public bool isChew;
    public bool isSpit;
    public bool isBreath;
    public bool isComeup;
    public bool isact;

    Vector3 lookVec;
    bool isLook; //공격할 때 보던방향 바라보도록

    void Awake()
    {
        meleeArea.enabled = false;
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
        targetRange = 18f;
    }

    IEnumerator Pattern()
    {
        nav.enabled = false;
        int ranAction = Random.Range(0, 3);
        yield return new WaitForSeconds(0.1f);
        switch (ranAction)
        {
            case 0:
                isChew = true;
                yield return StartCoroutine(Chew());
                break;
            case 1:
                isSpit = true;
                yield return StartCoroutine(Spit());
                break;
            case 2:
                isComeup = true;
                yield return StartCoroutine(Comeup());
                break;
        }
        nav.enabled = true;
        isact = false;
    }

    IEnumerator Chew()
    {
        isChew = true;
        yield return new WaitForSeconds(0.3f);

        this.gameObject.transform.Translate(new Vector3(0, 0, 14));
        anim.SetBool("isChew", true);//공격동작
        meleeArea.enabled = true;
        yield return new WaitForSeconds(0.1f);

        meleeArea.enabled = false;
        yield return new WaitForSeconds(0.3f);

        anim.SetBool("isChew", false);
        this.gameObject.transform.Translate(new Vector3(0, 0, -14));

        isChew = false;
    }
    IEnumerator Spit()
    {
        isSpit = true;
        anim.SetBool("isSpit", true);
        yield return new WaitForSeconds(0.2f);

        GameObject instantSpit = Instantiate(spit, spitpos.position, spitpos.rotation);
        Rigidbody rigidSpit = instantSpit.GetComponent<Rigidbody>();
        rigidSpit.velocity = transform.forward * 20;
        yield return new WaitForSeconds(0.2f);

        anim.SetBool("isSpit", false);
        isSpit = false;
    }
    public IEnumerator Comeup()
    {
        isComeup = true;
        anim.SetBool("isComeup", true);
        yield return new WaitForSeconds(3.2f);

        anim.SetBool("isComeup", false);
        isComeup = false;
    }

    public IEnumerator Fire()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject instantComeup = Instantiate(comeup, comeuppos[j].position, comeuppos[j].rotation);
                Rigidbody rigidComeup = instantComeup.GetComponent<Rigidbody>();
                rigidComeup.velocity = comeuppos[j].forward * 35;
                yield return null;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
