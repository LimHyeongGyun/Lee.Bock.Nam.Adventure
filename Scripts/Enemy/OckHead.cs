using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class OckHead : Enemy
{
    public GameObject spawner;

    public bool isSmite;
    public bool isTurnSwing;
    public bool isSummons;
    public bool isact;

    Vector3 lookVec;
    Vector3 rushVec;
    bool isLook; //������ �� �������� �ٶ󺸵���

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
            //�÷��̾��� �������� �����ϱ� ���ؼ� �÷��̾��� �Է°��� ���
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            //�÷��̾� �Է°����� ���� ���Ͱ��� ����� 5�� ����
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
        targetRange = 6f;
    }

    IEnumerator Pattern()
    {
        nav.enabled = false;
        int ranAction = Random.Range(0, 5);
        yield return new WaitForSeconds(0.1f);
        switch (ranAction)
        {
            case 0:
                isSmite = true;
                yield return StartCoroutine(Smite());
                break;
            case 1:
            case 2:
                isTurnSwing = true;
                yield return StartCoroutine(TurnSwing());
                break;           
            case 3:
            case 4:
                isSummons = true;
                yield return StartCoroutine(Summons());
                break;

        }
        nav.enabled = true;
        isact = false;
    }

    IEnumerator Smite()
    {
        isSmite = true;
        anim.SetBool("isSmite",true);//���ݵ���
        yield return new WaitForSeconds(2.4f); //�ִϸ��̼� ���۽ð� ���缭 �ٲ� ��

        anim.SetBool("isSmite", false);
        isSmite = false;
    }
    IEnumerator TurnSwing()
    {
        isTurnSwing = true;

        anim.SetBool("isTurnSwing",true);
        rigid.AddForce(transform.forward * 15, ForceMode.Impulse);
        rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(1.3f);

        anim.SetBool("isTurnSwing", false);
        isTurnSwing = false;
    }
    
    IEnumerator Summons()
    {
        isSummons = true;
        anim.SetBool("isSummons",true);
        yield return new WaitForSeconds(2f);

        if (isSummons == true)
        {
            for (int i = 0; i < 1; i++)
            {
                Spawn();
            }
        }
        anim.SetBool("isSummons", false);
        isSummons = false;
    }
    public void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2)); //Random.Range(0,2)
        enemy.transform.position = target.transform.position;// GetPosition();
    }
}