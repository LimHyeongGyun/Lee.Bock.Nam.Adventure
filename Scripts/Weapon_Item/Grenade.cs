using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public Rigidbody rigid;

    void Start()
    {       
        StartCoroutine(Explosion(rigid));
    }

    IEnumerator Explosion(Rigidbody other)
    {
        if(other.tag == "Enemy") //몬스터에게 직접 닿으면 터지지 않고 단일 데미지들어감 현재50데미지
        {
            yield return new WaitForSeconds(0f);
        }
        else // 직접 닿지 않으면 1초뒤에 광역으로 Nam 공격력만큼 데미지
        {
            yield return new WaitForSeconds(1f);
        }        
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        meshObj.SetActive(false);
        effectObj.SetActive(true);

        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 2.5f, Vector3.up, 0f, LayerMask.GetMask("Enemy"));
        
        foreach (RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<Enemy>().HitByGrenade(transform.position);
        }
        Destroy(gameObject,1f);
    }
}
