using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Exp : MonoBehaviour
{
    [SerializeField] Text levelText; //현재 레벨
    [SerializeField] Text curExpText; // 현재 경험치/필요 경험치 표시

    public static int maxExp = 50; //필요 경험치

    void Start()
    {
        LevelUp();
        Debug.Log("변경된 경험치" + maxExp);

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (SceneChangeManager.charactorNum == 2)
            {
                levelText.text = "LV : " + (playerInfo.LeeLv).ToString("00");
                curExpText.text = (playerInfo.LeeEXP).ToString("00") + "/" + maxExp.ToString("00");
            }
            else if (SceneChangeManager.charactorNum == 3)
            {
                levelText.text = "LV : " + (playerInfo.BockLv).ToString("00");
                curExpText.text = (playerInfo.BockEXP).ToString("00") + "/" + maxExp.ToString("00");
            }
            else if (SceneChangeManager.charactorNum == 4)
            {
                levelText.text = "LV : " + (playerInfo.NamLv).ToString("00");
                curExpText.text = (playerInfo.NamEXP).ToString("00") + "/" + maxExp.ToString("00");
            }
        }
    }

    public void LevelUp()
    {
        if (SceneChangeManager.charactorNum == 2)
        {
            while (maxExp <= playerInfo.LeeEXP)
            {
                Debug.Log("현재 최대 경험치" + maxExp);
                Debug.Log("현재 가지고있는 경험치" + playerInfo.LeeEXP);
                Debug.Log("현재 레벨" + playerInfo.LeeLv);
                playerInfo.LeeEXP -= playerInfo.LeeLv * 50;
                Debug.Log("현재 남은 경험치" + playerInfo.LeeEXP);
                playerInfo.LeeLv++;
                Debug.Log("현재 레벨" + playerInfo.LeeLv);
                playerInfo.leeStatpoint += 5;
                NeedEXP();
            }
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            while (maxExp <= playerInfo.BockEXP)
            {
                Debug.Log("현재 최대 경험치" + maxExp);
                Debug.Log("현재 가지고있는 경험치" + playerInfo.BockEXP);
                Debug.Log("현재 레벨" + playerInfo.BockLv);
                playerInfo.BockEXP -= playerInfo.BockLv * 50;
                Debug.Log("현재 남은 경험치" + playerInfo.BockEXP);
                playerInfo.BockLv++;
                Debug.Log("현재 레벨" + playerInfo.BockLv);
                playerInfo.bockStatpoint += 5;
                NeedEXP();
            }
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            while (maxExp <= playerInfo.NamEXP)
            {
                Debug.Log("현재 최대 경험치" + maxExp);
                Debug.Log("현재 가지고있는 경험치" + playerInfo.NamEXP);
                Debug.Log("현재 레벨" + playerInfo.NamLv);
                playerInfo.NamEXP -= playerInfo.NamLv * 50;
                Debug.Log("현재 남은 경험치" + playerInfo.NamEXP);
                playerInfo.NamLv++;
                Debug.Log("현재 레벨" + playerInfo.NamLv);
                playerInfo.namStatpoint += 5;
                NeedEXP();
            }
        }
    }

    public void NeedEXP()
    {
        if (SceneChangeManager.charactorNum == 2)
        {
            if (playerInfo.LeeLv == 1) maxExp = 50;
            else if (playerInfo.LeeLv == 2) maxExp = 100;
            else if (playerInfo.LeeLv == 3) maxExp = 150;
            else if (playerInfo.LeeLv == 4) maxExp = 200;
            else if (playerInfo.LeeLv == 5) maxExp = 250;
            else if (playerInfo.LeeLv == 6) maxExp = 300;
            else if (playerInfo.LeeLv == 7) maxExp = 350;
            else if (playerInfo.LeeLv == 8) maxExp = 400;
            else if (playerInfo.LeeLv == 9) maxExp = 450;
            else if (playerInfo.LeeLv == 10) maxExp = 500;
            else if (playerInfo.LeeLv == 11) maxExp = 550;
            else if (playerInfo.LeeLv == 12) maxExp = 600;
            else if (playerInfo.LeeLv == 13) maxExp = 650;
            else if (playerInfo.LeeLv == 14) maxExp = 700;
            else if (playerInfo.LeeLv == 15) maxExp = 750;
            else if (playerInfo.LeeLv == 16) maxExp = 800;
            else if (playerInfo.LeeLv == 17) maxExp = 850;
            else if (playerInfo.LeeLv == 18) maxExp = 900;
            else if (playerInfo.LeeLv == 19) maxExp = 950;
            else if (playerInfo.LeeLv == 20) maxExp = 1000;
            else if (playerInfo.LeeLv > 20) maxExp = 5000;
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            if (playerInfo.BockLv == 1) maxExp = 50;
            else if (playerInfo.BockLv == 2) maxExp = 100;
            else if (playerInfo.BockLv == 3) maxExp = 150;
            else if (playerInfo.BockLv == 4) maxExp = 200;
            else if (playerInfo.BockLv == 5) maxExp = 250;
            else if (playerInfo.BockLv == 6) maxExp = 300;
            else if (playerInfo.BockLv == 7) maxExp = 350;
            else if (playerInfo.BockLv == 8) maxExp = 400;
            else if (playerInfo.BockLv == 9) maxExp = 450;
            else if (playerInfo.BockLv == 10) maxExp = 500;
            else if (playerInfo.BockLv == 11) maxExp = 550;
            else if (playerInfo.BockLv == 12) maxExp = 600;
            else if (playerInfo.BockLv == 13) maxExp = 650;
            else if (playerInfo.BockLv == 14) maxExp = 700;
            else if (playerInfo.BockLv == 15) maxExp = 750;
            else if (playerInfo.BockLv == 16) maxExp = 800;
            else if (playerInfo.BockLv == 17) maxExp = 850;
            else if (playerInfo.BockLv == 18) maxExp = 900;
            else if (playerInfo.BockLv == 19) maxExp = 950;
            else if (playerInfo.BockLv == 20) maxExp = 1000;
            else if (playerInfo.BockLv > 20) maxExp = 5000;
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            if (playerInfo.NamLv == 1) maxExp = 50;
            else if (playerInfo.NamLv == 2) maxExp = 100;
            else if (playerInfo.NamLv == 3) maxExp = 150;
            else if (playerInfo.NamLv == 4) maxExp = 200;
            else if (playerInfo.NamLv == 5) maxExp = 250;
            else if (playerInfo.NamLv == 6) maxExp = 300;
            else if (playerInfo.NamLv == 7) maxExp = 350;
            else if (playerInfo.NamLv == 8) maxExp = 400;
            else if (playerInfo.NamLv == 9) maxExp = 450;
            else if (playerInfo.NamLv == 10) maxExp = 500;
            else if (playerInfo.NamLv == 11) maxExp = 550;
            else if (playerInfo.NamLv == 12) maxExp = 600;
            else if (playerInfo.NamLv == 13) maxExp = 650;
            else if (playerInfo.NamLv == 14) maxExp = 700;
            else if (playerInfo.NamLv == 15) maxExp = 750;
            else if (playerInfo.NamLv == 16) maxExp = 800;
            else if (playerInfo.NamLv == 17) maxExp = 850;
            else if (playerInfo.NamLv == 18) maxExp = 900;
            else if (playerInfo.NamLv == 19) maxExp = 950;
            else if (playerInfo.NamLv == 20) maxExp = 1000;
            else if(playerInfo.NamLv > 20) maxExp = 5000;
        }
    }
    public void GiveEXP()
    {
        if(SceneChangeManager.charactorNum == 2)
        {
            if (SceneChangeManager.selectNum == 11) playerInfo.LeeEXP += 40;
            else if (SceneChangeManager.selectNum == 12) playerInfo.LeeEXP += 30;
            else if (SceneChangeManager.selectNum == 13) playerInfo.LeeEXP += 40;
            else if (SceneChangeManager.selectNum == 14) playerInfo.LeeEXP += 60;
            else if (SceneChangeManager.selectNum == 15) playerInfo.LeeEXP += 150;
            else if (SceneChangeManager.selectNum == 21) playerInfo.LeeEXP += 150;
            else if (SceneChangeManager.selectNum == 22) playerInfo.LeeEXP += 150;
            else if (SceneChangeManager.selectNum == 23) playerInfo.LeeEXP += 150;
            else if (SceneChangeManager.selectNum == 24) playerInfo.LeeEXP += 200;
            else if (SceneChangeManager.selectNum == 25) playerInfo.LeeEXP += 250;
            else if (SceneChangeManager.selectNum == 31) playerInfo.LeeEXP += 250;
            else if (SceneChangeManager.selectNum == 32) playerInfo.LeeEXP += 250;
            else if (SceneChangeManager.selectNum == 33) playerInfo.LeeEXP += 300;
            else if (SceneChangeManager.selectNum == 34) playerInfo.LeeEXP += 300;
            else if (SceneChangeManager.selectNum == 35) playerInfo.LeeEXP += 350;
            else if (SceneChangeManager.selectNum == 41) playerInfo.LeeEXP += 400;
            else if (SceneChangeManager.selectNum == 42) playerInfo.LeeEXP += 400;
            else if (SceneChangeManager.selectNum == 43) playerInfo.LeeEXP += 400;
            else if (SceneChangeManager.selectNum == 44) playerInfo.LeeEXP += 400;
            else if (SceneChangeManager.selectNum == 45) playerInfo.LeeEXP += 450;
            else if (SceneChangeManager.selectNum == 51) playerInfo.LeeEXP += 450;
            else if (SceneChangeManager.selectNum == 52) playerInfo.LeeEXP += 450;
            else if (SceneChangeManager.selectNum == 53) playerInfo.LeeEXP += 450;
            else if (SceneChangeManager.selectNum == 54) playerInfo.LeeEXP += 450;
            else if (SceneChangeManager.selectNum == 55) playerInfo.LeeEXP += 1000;
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            if (SceneChangeManager.selectNum == 11) playerInfo.BockEXP += 40;
            else if (SceneChangeManager.selectNum == 12) playerInfo.BockEXP += 30;
            else if (SceneChangeManager.selectNum == 13) playerInfo.BockEXP += 40;
            else if (SceneChangeManager.selectNum == 14) playerInfo.BockEXP += 60;
            else if (SceneChangeManager.selectNum == 15) playerInfo.BockEXP += 150;
            else if (SceneChangeManager.selectNum == 21) playerInfo.BockEXP += 150;
            else if (SceneChangeManager.selectNum == 22) playerInfo.BockEXP += 150;
            else if (SceneChangeManager.selectNum == 23) playerInfo.BockEXP += 150;
            else if (SceneChangeManager.selectNum == 24) playerInfo.BockEXP += 200;
            else if (SceneChangeManager.selectNum == 25) playerInfo.BockEXP += 250;
            else if (SceneChangeManager.selectNum == 31) playerInfo.BockEXP += 250;
            else if (SceneChangeManager.selectNum == 32) playerInfo.BockEXP += 250;
            else if (SceneChangeManager.selectNum == 33) playerInfo.BockEXP += 300;
            else if (SceneChangeManager.selectNum == 34) playerInfo.BockEXP += 300;
            else if (SceneChangeManager.selectNum == 35) playerInfo.BockEXP += 350;
            else if (SceneChangeManager.selectNum == 41) playerInfo.BockEXP += 400;
            else if (SceneChangeManager.selectNum == 42) playerInfo.BockEXP += 400;
            else if (SceneChangeManager.selectNum == 43) playerInfo.BockEXP += 400;
            else if (SceneChangeManager.selectNum == 44) playerInfo.BockEXP += 400;
            else if (SceneChangeManager.selectNum == 45) playerInfo.BockEXP += 450;
            else if (SceneChangeManager.selectNum == 51) playerInfo.BockEXP += 450;
            else if (SceneChangeManager.selectNum == 52) playerInfo.BockEXP += 450;
            else if (SceneChangeManager.selectNum == 53) playerInfo.BockEXP += 450;
            else if (SceneChangeManager.selectNum == 54) playerInfo.BockEXP += 450;
            else if (SceneChangeManager.selectNum == 55) playerInfo.BockEXP += 1000;
        }
        if (SceneChangeManager.charactorNum == 4)
        {
            if (SceneChangeManager.selectNum == 11) playerInfo.NamEXP += 40;
            else if (SceneChangeManager.selectNum == 12) playerInfo.NamEXP += 30;
            else if (SceneChangeManager.selectNum == 13) playerInfo.NamEXP += 40;
            else if (SceneChangeManager.selectNum == 14) playerInfo.NamEXP += 60;
            else if (SceneChangeManager.selectNum == 15) playerInfo.NamEXP += 150;
            else if (SceneChangeManager.selectNum == 21) playerInfo.NamEXP += 150;
            else if (SceneChangeManager.selectNum == 22) playerInfo.NamEXP += 150;
            else if (SceneChangeManager.selectNum == 23) playerInfo.NamEXP += 150;
            else if (SceneChangeManager.selectNum == 24) playerInfo.NamEXP += 200;
            else if (SceneChangeManager.selectNum == 25) playerInfo.NamEXP += 250;
            else if (SceneChangeManager.selectNum == 31) playerInfo.NamEXP += 250;
            else if (SceneChangeManager.selectNum == 32) playerInfo.NamEXP += 250;
            else if (SceneChangeManager.selectNum == 33) playerInfo.NamEXP += 300;
            else if (SceneChangeManager.selectNum == 34) playerInfo.NamEXP += 300;
            else if (SceneChangeManager.selectNum == 35) playerInfo.NamEXP += 350;
            else if (SceneChangeManager.selectNum == 41) playerInfo.NamEXP += 400;
            else if (SceneChangeManager.selectNum == 42) playerInfo.NamEXP += 400;
            else if (SceneChangeManager.selectNum == 43) playerInfo.NamEXP += 400;
            else if (SceneChangeManager.selectNum == 44) playerInfo.NamEXP += 400;
            else if (SceneChangeManager.selectNum == 45) playerInfo.NamEXP += 450;
            else if (SceneChangeManager.selectNum == 51) playerInfo.NamEXP += 450;
            else if (SceneChangeManager.selectNum == 52) playerInfo.NamEXP += 450;
            else if (SceneChangeManager.selectNum == 53) playerInfo.NamEXP += 450;
            else if (SceneChangeManager.selectNum == 54) playerInfo.NamEXP += 450;
            else if (SceneChangeManager.selectNum == 55) playerInfo.NamEXP += 1000;
        }
    }
}
