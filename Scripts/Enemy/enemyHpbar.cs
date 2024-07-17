using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHpbar : MonoBehaviour
{
    public Enemy enemy;

    public Transform enemyT;
    public Slider enemyhpBar;
    public float maxHP;
    float curHP;

    void Start()
    {
        maxHP = enemy.maxHealth;
    }

    void Update()
    {
        transform.position = enemyT.position;

        curHP = enemy.curHealth;
        enemyhpBar.value = curHP / maxHP;
    }
}
