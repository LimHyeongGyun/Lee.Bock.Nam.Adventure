using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range, Magic };
    public Type type;
    public float rate; // 공격속도
    private BoxCollider meleeArea;
    private TrailRenderer trail;

    public Transform arrowPos1;
    public Transform arrowPos2;
    public Transform arrowPos3;
    public GameObject arrow;
    public Transform firePos;
    public GameObject fire;
    
    private WaitForSeconds WT_0point1 = new(0.1f);
    private WaitForSeconds WT_0point2 = new(0.2f);  

    private void Start()
    {
        if (type == Type.Melee) //Lee캐릭터에서만 작용하도록 설정
        {
            meleeArea = gameObject.GetComponentInParent<BoxCollider>();
            trail = transform.GetChild(0).GetComponent<TrailRenderer>();
            
            meleeArea.enabled = false;
            trail.enabled = false;
        }        
    }

    public void Use()
    {
        if(type == Type.Melee) //Lee
        {
            StopCoroutine(Swing());
            StartCoroutine(Swing());
        }
        else if (type == Type.Range) //Bock
        {
            StopCoroutine(Shot());
            StartCoroutine(Shot());
        }
        if (type == Type.Magic) //Nam
        {
            Spell();
        }
    }

    IEnumerator Swing()
    {
        trail.enabled = true;
        yield return WT_0point1; // 공격을 해도 적이 안맞는 이유가 콜라이더인지 시간설정인지 알아내서 섬세한 공격 가능하게 만들어야함
        
        meleeArea.enabled = true;
        yield return WT_0point1;

        trail.enabled = false;
        meleeArea.enabled = false;
    }

    IEnumerator Shot()
    {
        yield return WT_0point2;
        GameObject instantArrow1 = Instantiate(arrow, arrowPos1.position, arrowPos1.rotation); //화살 발사
        GameObject instantArrow2 = Instantiate(arrow, arrowPos2.position, arrowPos2.rotation);
        GameObject instantArrow3 = Instantiate(arrow, arrowPos3.position, arrowPos3.rotation);
        Rigidbody arrowRigid1 = instantArrow1.GetComponent<Rigidbody>();
        Rigidbody arrowRigid2 = instantArrow2.GetComponent<Rigidbody>();
        Rigidbody arrowRigid3 = instantArrow3.GetComponent<Rigidbody>();
        arrowRigid1.velocity = arrowPos1.forward * 30; //발사속도
        arrowRigid2.velocity = arrowPos2.forward * 30;
        arrowRigid3.velocity = arrowPos3.forward * 30;
    }

    void Spell()
    {
        Vector3 nextVec = firePos.position - transform.position;
        nextVec.y = 2;

        GameObject instantFire = Instantiate(fire, firePos.position, firePos.rotation); //마법 발사
        Rigidbody fireRigid = instantFire.GetComponent<Rigidbody>();
        fireRigid.velocity = firePos.forward * 5; //발사속도
        fireRigid.AddTorque(Vector3.back, ForceMode.Impulse);
    }
}
