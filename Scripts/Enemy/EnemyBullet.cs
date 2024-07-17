using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public enum Type { Bullet, Breath };
    public Type attackType;
    public int damage;
    public bool isMelee;
    public bool isRock;

    public bool glacier;
    public bool snowfloor;

    private void Update()
    {
        if (attackType == Type.Breath) Destroy(gameObject, 0.8f); //코브라 브레스 길이감소를 위해설정
        BossPattern();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!isRock && collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isMelee && other.gameObject.tag == "Wall" || !isMelee && other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    private void BossPattern()
    {
        if (glacier == true)
        {
            Destroy(gameObject, 2);
        }
        if(snowfloor == true)
        {
            StartCoroutine(OnOff());
            Destroy(gameObject, 3.5f);
        }
    }
    
    IEnumerator OnOff()
    {
        for (int i = 0; i < 8; i++)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            gameObject.SetActive(false);
        }
    }
}
