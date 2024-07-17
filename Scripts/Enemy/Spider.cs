using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Spider : Enemy
{
    public GameObject spawner;
    public GameObject web;

    public Transform webpos;

    public bool isBite;
    public bool isSummons;
    public bool isWeb;
    public bool isact;

    Vector3 destination = new Vector3 (40, 0, 0);
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
        targetRange = 20f;
    }

    IEnumerator Pattern()
    {
        nav.enabled = false;
        int ranAction = Random.Range(0, 3);
        yield return new WaitForSeconds(0.1f);
        switch (ranAction)
        {
            case 0:
                isBite = true;
                yield return StartCoroutine(Bite());
                break;
            case 1:
                isWeb = true;
                yield return StartCoroutine(Web());
                break;
                
            case 2:
                isSummons = true;
                yield return StartCoroutine(Summon()); 
                break;
        }
        isact = false;
    }

    IEnumerator Bite()
    {
        isBite = true;
        this.gameObject.transform.Translate(new Vector3(0, 0, 11));
        anim.SetBool("isBite", true);//공격동작
        yield return new WaitForSeconds(0.3f);

        anim.SetBool("isBite", false);
        this.gameObject.transform.Translate(new Vector3(0, 0, -11));

        isBite = false;
        nav.enabled = true;
    }
    
    IEnumerator Summon()
    {
        isSummons = true;
        anim.SetBool("isSummons", true);
        yield return new WaitForSeconds(0.3f);

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
    
    public IEnumerator Web()
    {
        isWeb = true;
        this.gameObject.transform.Rotate(new Vector3(0, -30, 0));
        for (int i = 0; i< 6; i++)
        {
            anim.SetBool("isWeb", true);
            GameObject instantweb = Instantiate(web, webpos.position, webpos.rotation);
            Rigidbody rigidweb = instantweb.GetComponent<Rigidbody>();
            rigidweb.velocity = transform.forward * 20;
            this.gameObject.transform.Rotate(new Vector3(0, 30, 0));
            yield return new WaitForSeconds(0.075f);
            anim.SetBool("isWeb", false);
        }
        this.gameObject.transform.Rotate(new Vector3(0, -90, 0));
        yield return new WaitForSeconds(0.5f);
        isWeb = false;
        nav.enabled = true;
    }
    public void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 3));
        enemy.transform.position = target.transform.position;
    }
}