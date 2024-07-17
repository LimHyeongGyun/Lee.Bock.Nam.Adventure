using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class IceGolem : Enemy
{
    public GameObject glacier;
    public GameObject hail;
    public GameObject downicicle;
    public GameObject snow;

    public Transform icicleshotpos;
    public Transform glacierpos;
    public Transform snowfloor;
    public Transform hailpos1;
    public Transform hailpos2;
    public Transform hailpos3;

    public bool isIcicle;
    public bool isGlacier;
    public bool isHail;
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
                isIcicle = true;
                yield return StartCoroutine(Icicle());
                break;
            case 1:
                isGlacier = true;
                yield return StartCoroutine(Glacier());
                break;
            case 2:
                isHail = true;
                yield return StartCoroutine(Hail());
                break;
        }
        isact = false;
    }

    IEnumerator Icicle()
    {
        isIcicle = true;
        anim.SetBool("isIcicle", true);//공격동작
        yield return new WaitForSeconds(0.7f);

        anim.SetBool("isIcicle", false);
        GameObject instantBullet = Instantiate(bullet, icicleshotpos.position, icicleshotpos.rotation);
        Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();
        rigidBullet.velocity = transform.forward * 50;

        isIcicle = false;
        nav.enabled = true;
    }
    IEnumerator Glacier()
    {
        isGlacier = true;
        anim.SetBool("isGlacier", true);
        GameObject instantglacier = Instantiate(glacier, glacierpos.position, glacierpos.rotation);
        Rigidbody rigidglacier = instantglacier.GetComponent<Rigidbody>();
        yield return new WaitForSeconds(0.6f);

        rigidglacier.transform.position = Vector3.MoveTowards(transform.position, UpPosition(), 10);
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("isGlacier", false);
        isGlacier = false;
        nav.enabled = true;
    }
    public IEnumerator Hail()
    {
        isHail = true;
        anim.SetBool("isHail", true);
        GameObject instantsnow = Instantiate(snow, snowfloor.position, snowfloor.rotation);
        yield return new WaitForSeconds(1.5f);

        GameObject instanthail1 = Instantiate(downicicle, hailpos1.position, hailpos1.rotation);
        Rigidbody rigidhail1 = instanthail1.GetComponent<Rigidbody>();
        rigidhail1.velocity = hailpos1.up * -40;
        yield return new WaitForSeconds(1.1f);

        for (int i = 0; i<2; i++)
        {
            GameObject instanthail2 = Instantiate(hail, hailpos2.position, hailpos2.rotation);
            Rigidbody rigidhail2 = instanthail2.GetComponent<Rigidbody>();
            GameObject instanthail3 = Instantiate(hail, hailpos3.position, hailpos3.rotation);
            Rigidbody rigidhail3 = instanthail3.GetComponent<Rigidbody>();
            rigidhail2.velocity = hailpos2.forward * 50;
            rigidhail3.velocity = hailpos3.forward * 50;
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("isHail", false);
        isHail = false;
        nav.enabled = true;
    }

    private Vector3 UpPosition()
    {
        Vector3 basePosition = glacierpos.transform.position;

        float posX = basePosition.x;
        float posY = -1.5f;
        float posZ = basePosition.z;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);
     
        return spawnPos;
    }
}
