using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform dmgPos;
    public GameObject PlayerDmgText;
    public GameObject[] weapons;
    public bool[] hasWeapons;
    public GameObject[] potions;
    public int hasPotions;
    public GameObject potionObj;

    public static int playHealth; //���� �÷��� �� �� �޾ƿ� static�� ����� �÷��̾� ü��
    public static float playSpeed;
    int attackNum = 0;
    float hAxis;
    float vAxis;

    bool fDown;
    bool pDown; // ������ e ��ư ������ �Ծ���

    bool isFireReady;

    public bool isact;
    bool isBorder;
    bool isDamage;
    bool isDead = false;

    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;
    Material mat;
    MeshRenderer[] meshs;

    GameObject nearObject;

    CheckEnemy  checkenemy; 
    Weapon equipWeapon;
    int equipWeaponIndex = -1;

    float fireDelay;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        meshs = GetComponentsInChildren<MeshRenderer>();
    }

    void Start()
    {
        if (SceneChangeManager.charactorNum == 2)
        {
            playHealth = playerInfo.LeeHealth;
            playSpeed = playerInfo.LeeSpeed;
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            playHealth = playerInfo.BockHealth;
            playSpeed = playerInfo.BockSpeed;
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            playHealth = playerInfo.NamHealth;
            playSpeed = playerInfo.NamSpeed;
        }
        HaveWeapon();
    }

    void Update()
    {
        GetInput();
        Survive();
        Lose();
        Potion();      
        if(GameManager.gameState == State.Playing)//���� �÷��� �����϶��� �Լ��� �۵��ϵ��� �߰��� ����
        {
            Move();
            Turn();
            Attack();
        }
    }
    
    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero; //����ȸ���ӵ� 0���� ���� - ĳ���� �ڵ�ȸ�� X
    }

    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward * 1, Color.green);
        isBorder = Physics.Raycast(transform.position, transform.forward, 1, LayerMask.GetMask("Wall"));
    }

    void FixedUpdate()
    {
        FreezeRotation();
        StopToWall();
    }
    void Potion()
    {        
        if (hasPotions == 0)
            return;

        if(pDown && !fDown)
        {
            potions[hasPotions-1].SetActive(false); // 3, 2, 1, 0�� �迭�� �ִ� ���� ���� ����
            hasPotions--;  //  ���� �迭�� �ִ� ���� ���� ����

            if (SceneChangeManager.charactorNum == 2)
            {
                playHealth += 100;
                if (playHealth >= playerInfo.LeeHealth) playHealth = playerInfo.LeeHealth;
            }                
            else if (SceneChangeManager.charactorNum == 3)
            {
                playHealth += 100;
                if (playHealth >= playerInfo.BockHealth) playHealth = playerInfo.BockHealth;
            }             
            else if (SceneChangeManager.charactorNum == 4)
            {
                playHealth += 100;
                if (playHealth >= playerInfo.NamHealth) playHealth = playerInfo.NamHealth;
            }          
        }
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        fDown = Input.GetKey(KeyCode.Space);
        pDown = Input.GetButtonDown("Potion");     
    }

    void Move()
    {
        if (!isact)
        {
            moveVec = new Vector3(hAxis, 0, vAxis).normalized;

            if (!isBorder && equipWeapon.type == Weapon.Type.Magic ? !fDown : !isBorder) // ������ ������ �� �̵� ���ϵ��� ���׿����� �߰�
            {
                transform.position += moveVec * playSpeed * Time.deltaTime;
            }

            anim.SetBool("isRun", moveVec != Vector3.zero);
        }
    }

    void Turn()
    {
        if (!isact) transform.LookAt(transform.position + moveVec);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            if (!isDamage)
            {
                EnemyBullet enemyAttack = other.GetComponent<EnemyBullet>();
                playHealth -= enemyAttack.damage;
                Vector3 reactVec = transform.position - other.transform.position; //����� ���� �������� �˹�

                GameObject playerText = Instantiate(PlayerDmgText);
                playerText.transform.position = dmgPos.position;
                playerText.GetComponent<DamageText>().damage = enemyAttack.damage;
                StartCoroutine(OnDamage(reactVec));
            }
        }

        if(other.gameObject.name == "Chew")
        {
            if(!isact)
                StartCoroutine(DizzyTime());
        }

        if(other.tag == "Wall")
        {
            if (!isDamage)
            {
                EnemyBullet enemyAttack = other.GetComponent<EnemyBullet>();
                playHealth -= enemyAttack.damage;
                Vector3 reactVec = transform.position - other.transform.position; //����� ���� �������� �˹�

                GameObject playerText = Instantiate(PlayerDmgText);
                playerText.transform.position = dmgPos.position;
                playerText.GetComponent<DamageText>().damage = enemyAttack.damage;
                StartCoroutine(OnDamage(reactVec));
            }
        }       
    }

    IEnumerator DizzyTime()
    {
        isact = true;
        for (int i = 0; i < 2; i++)
        {
            anim.SetBool("isDizzy", true);
            yield return new WaitForSecondsRealtime(1.1f);
            anim.SetBool("isDizzy", false);
        }

        isact = false;
    }

IEnumerator OnDamage(Vector3 reactVec)
    {
        //�ǰ� ���׼�
        isDamage = true;

        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
            if (playHealth > 0)
            {
                anim.SetTrigger("beAttacked");
            }
        }
        yield return new WaitForSeconds(0.05f);// 0.1�� ����
        isDamage = false;
        if (playHealth > 0)
        {
            foreach (MeshRenderer mesh in meshs)
            {
                mesh.material.color = new Color(1, 1, 1);
            }
        }
        else
        {
            foreach (MeshRenderer mesh in meshs)
            {
                mesh.material.color = Color.gray;
            }
            gameObject.layer = 13;
            anim.SetTrigger("doDie");

            yield return new WaitForSeconds(1f);
            OnDie();

            yield return null;
        }
    }

    void Attack()
    {
        if (!isact)
        {
            fireDelay += Time.deltaTime;
            isFireReady = equipWeapon.rate < fireDelay;

            if (fDown && isFireReady)
            {
                equipWeapon.Use();
                anim.SetTrigger(equipWeapon.type == Weapon.Type.Melee ? "doAttack" : "doShot");
                fireDelay = 0;

                if (attackNum == 3)
                {
                    anim.SetInteger("attackNum", 0);
                    attackNum = 0;
                }
                else if (equipWeapon.type == Weapon.Type.Melee)
                {
                    anim.SetInteger("attackNum", ++attackNum);
                }
                else
                {
                    attackNum = 0;
                }
            }
        }
    }

    void HaveWeapon() //���Ⱑ �迭�� �ִٶ�� ���� �޾��ְ�, ���Ŀ� ĳ���� ������ ���� � ���⸦ ����Ұ����� �����ִ� �Լ�
    {
        int weaponIndex = 0;
        equipWeaponIndex = weaponIndex;
        equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
            nearObject = null;
        if(other.tag == "cobrastaff")
        {
            rigid.drag = 20;
        }
    }

    public void Survive() // Player��ũ��Ʈ���� GameManager�� ��︮�� �Լ��ΰŰ���. 4.27��
    {
        if (CountdownTimer.currentTime > 0)  //���ѽð��� ����������
        {
            if (CheckEnemy.curEnemy == 0) // ���� ���� 0�����϶�
            {
                GameManager.gameState = State.GameClear;
            }
        }
    }

    public void Lose()
    {
        if (CountdownTimer.currentTime == 0 && CheckEnemy.curEnemy > 0)
        {
            GameManager.gameState = State.GameOver;
        }
        if (CountdownTimer.currentTime == 0 && CheckEnemy.curbossEnemy > 0)
        {
            GameManager.gameState = State.GameOver;
        }
    }

    public void OnDie()
    {
        isDead = true;
        GameManager.gameState = State.GameOver;
    }
}
