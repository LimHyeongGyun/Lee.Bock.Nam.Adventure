using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public void PlayerSave()
    {
        //saveBtn을 눌렀을 때 PlayerPrefs 클래스로 캐릭터 정보를 저장
        if(this.gameObject.name == "saveBtn")
        {
            PlayerPrefs.SetFloat("LD", playerInfo.LeeDamage);
            PlayerPrefs.SetFloat("LS", playerInfo.LeeSpeed);
            PlayerPrefs.SetInt("LH", playerInfo.LeeHealth);
            PlayerPrefs.SetInt("LEXP", playerInfo.LeeEXP);
            PlayerPrefs.SetInt("LLV", playerInfo.LeeLv);
            PlayerPrefs.SetInt("Lstatpoint", playerInfo.leeStatpoint);
            PlayerPrefs.SetInt("LDpoint", playerInfo.leeDSpoint);
            PlayerPrefs.SetInt("LHpoint", playerInfo.leeHSpoint);
            PlayerPrefs.SetInt("LSpoint", playerInfo.leeSSpoint);

            PlayerPrefs.SetFloat("BD", playerInfo.BockDamage);
            PlayerPrefs.SetFloat("BS", playerInfo.BockSpeed);
            PlayerPrefs.SetInt("BH", playerInfo.BockHealth);
            PlayerPrefs.SetInt("BEXP", playerInfo.BockEXP);
            PlayerPrefs.SetInt("BLV", playerInfo.BockLv);
            PlayerPrefs.SetInt("Bstatpoint", playerInfo.bockStatpoint);
            PlayerPrefs.SetInt("BDpoint", playerInfo.bockDSpoint);
            PlayerPrefs.SetInt("BHpoint", playerInfo.bockHSpoint);
            PlayerPrefs.SetInt("BSpoint", playerInfo.bockSSpoint);

            PlayerPrefs.SetFloat("ND", playerInfo.NamDamage);
            PlayerPrefs.SetFloat("NS", playerInfo.NamSpeed);
            PlayerPrefs.SetInt("NH", playerInfo.NamHealth);
            PlayerPrefs.SetInt("NEXP", playerInfo.NamEXP);
            PlayerPrefs.SetInt("NLV", playerInfo.NamLv);
            PlayerPrefs.SetInt("Nstatpoint", playerInfo.namStatpoint);
            PlayerPrefs.SetInt("NDpoint", playerInfo.namDSpoint);
            PlayerPrefs.SetInt("NHpoint", playerInfo.namHSpoint);
            PlayerPrefs.SetInt("NSpoint", playerInfo.namSSpoint);

            PlayerPrefs.Save();
        }
    }
    public void PlayerLoad()
    {
        if (!PlayerPrefs.HasKey("LD"))
            return;
        playerInfo.LeeDamage = PlayerPrefs.GetFloat("LD");
        playerInfo.LeeSpeed = PlayerPrefs.GetFloat("LS");
        playerInfo.LeeHealth = PlayerPrefs.GetInt("LH");
        playerInfo.LeeEXP = PlayerPrefs.GetInt("LEXP");
        playerInfo.LeeLv = PlayerPrefs.GetInt("LLV");
        playerInfo.leeStatpoint = PlayerPrefs.GetInt("Lstatpoint");
        playerInfo.leeDSpoint = PlayerPrefs.GetInt("LDpoint");
        playerInfo.leeHSpoint = PlayerPrefs.GetInt("LHpoint");
        playerInfo.leeSSpoint = PlayerPrefs.GetInt("LSpoint");

        playerInfo.BockDamage = PlayerPrefs.GetFloat("BD");
        playerInfo.BockSpeed = PlayerPrefs.GetFloat("BS");
        playerInfo.BockHealth = PlayerPrefs.GetInt("BH");
        playerInfo.BockEXP = PlayerPrefs.GetInt("BEXP");
        playerInfo.BockLv = PlayerPrefs.GetInt("BLV");
        playerInfo.bockStatpoint = PlayerPrefs.GetInt("Bstatpoint");
        playerInfo.bockDSpoint = PlayerPrefs.GetInt("BDpoint");
        playerInfo.bockHSpoint = PlayerPrefs.GetInt("BHpoint");
        playerInfo.bockSSpoint = PlayerPrefs.GetInt("BSpoint");

        playerInfo.NamDamage = PlayerPrefs.GetFloat("ND");
        playerInfo.NamSpeed = PlayerPrefs.GetFloat("NS");
        playerInfo.NamHealth = PlayerPrefs.GetInt("NH");
        playerInfo.NamEXP = PlayerPrefs.GetInt("NEXP");
        playerInfo.NamLv = PlayerPrefs.GetInt("NLV");
        playerInfo.namStatpoint = PlayerPrefs.GetInt("Nstatpoint");
        playerInfo.namDSpoint = PlayerPrefs.GetInt("NDpoint");
        playerInfo.namHSpoint = PlayerPrefs.GetInt("NHpoint");
        playerInfo.namSSpoint = PlayerPrefs.GetInt("NSpoint");
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
