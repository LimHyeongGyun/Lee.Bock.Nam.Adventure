using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HpBar : MonoBehaviour
{
    public Transform player;
    public Slider hpBar;
    public float maxHp;
    public float currentHp;

    void Update()
    {
        if(SceneChangeManager.charactorNum == 2) maxHp = playerInfo.LeeHealth;
        else if (SceneChangeManager.charactorNum == 3) maxHp = playerInfo.BockHealth;
        else if (SceneChangeManager.charactorNum == 4) maxHp = playerInfo.NamHealth;
        transform.position = player.position;
        currentHp = Player.playHealth;
        hpBar.value = currentHp / maxHp;
    }
}
