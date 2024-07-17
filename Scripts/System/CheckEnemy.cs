using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEnemy : MonoBehaviour
{
    public int bossEnemy;
    public int maxEnemy;
    public static int curEnemy = 0;
    public static int curbossEnemy = 0;

    [SerializeField] Text countEnemyText;

    void Start()
    {
        curbossEnemy = bossEnemy;
        curEnemy = maxEnemy;
    }

    void Update()
    {
        countEnemyText.color = Color.white;
        countEnemyText.text = "Enemy : " + curEnemy.ToString();
    }
}
