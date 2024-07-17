using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StatsPlus : MonoBehaviour
{
    float truncatedLee = Mathf.Round(playerInfo.LeeDamage * 10f) / 10f;
    float truncatedBock = Mathf.Round(playerInfo.BockDamage * 10f) / 10f;
    float truncatedNam = Mathf.Round(playerInfo.NamDamage * 10f) / 10f;
    float truncatedLeeS = Mathf.Round(playerInfo.LeeSpeed * 10f) / 10f;
    float truncatedBockS = Mathf.Round(playerInfo.BockSpeed * 10f) / 10f;
    float truncatedNamS = Mathf.Round(playerInfo.NamSpeed * 10f) / 10f;
    private void Start()
    {
        // ĳ���� ��ȣ�� ���� ������ ���� ���� ����Ʈ�� ������

        if (SceneChangeManager.charactorNum == 2){
            GameObject.Find("StatCount_DText").GetComponent<Text>().text = (playerInfo.leeDSpoint).ToString() + "/100" + "\n +0.7";
            GameObject.Find("StatCount_HText").GetComponent<Text>().text = (playerInfo.leeHSpoint).ToString() + "/100" + "\n +45";
            GameObject.Find("StatCount_SText").GetComponent<Text>().text = (playerInfo.leeSSpoint).ToString() + "/100" + "\n +0.1";
            GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.leeStatpoint).ToString();
            GameObject.Find("DStatus").GetComponent<Text>().text = "���ݷ� : " + (truncatedLee).ToString();
            GameObject.Find("HStatus").GetComponent<Text>().text = "ü�� : " + (playerInfo.LeeHealth).ToString();
            GameObject.Find("SStatus").GetComponent<Text>().text = "�̵��ӵ� : " + (truncatedLeeS).ToString();
        }
        if(SceneChangeManager.charactorNum == 3){
            GameObject.Find("StatCount_DText").GetComponent<Text>().text = (playerInfo.bockDSpoint).ToString() + "/100" + "\n +0.7";
            GameObject.Find("StatCount_HText").GetComponent<Text>().text = (playerInfo.bockHSpoint).ToString() + "/100" + "\n +30";
            GameObject.Find("StatCount_SText").GetComponent<Text>().text = (playerInfo.bockSSpoint).ToString() + "/100" + "\n +0.2";
            GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.bockStatpoint).ToString();
            GameObject.Find("DStatus").GetComponent<Text>().text = "���ݷ� : " + (truncatedBock).ToString();
            GameObject.Find("HStatus").GetComponent<Text>().text = "ü�� : " + (playerInfo.BockHealth).ToString();
            GameObject.Find("SStatus").GetComponent<Text>().text = "�̵��ӵ� : " + (truncatedBockS).ToString();
        }
        if (SceneChangeManager.charactorNum == 4)
        {
            GameObject.Find("StatCount_DText").GetComponent<Text>().text = (playerInfo.namDSpoint).ToString() + "/100" + "\n +1.0";
            GameObject.Find("StatCount_HText").GetComponent<Text>().text = (playerInfo.namHSpoint).ToString() + "/100" + "\n +30";
            GameObject.Find("StatCount_SText").GetComponent<Text>().text = (playerInfo.namSSpoint).ToString() + "/100" + "\n +0.1";
            GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.namStatpoint).ToString();
            GameObject.Find("DStatus").GetComponent<Text>().text = "���ݷ� : " + (truncatedNam).ToString();
            GameObject.Find("HStatus").GetComponent<Text>().text = "ü�� : " + (playerInfo.NamHealth).ToString();
            GameObject.Find("SStatus").GetComponent<Text>().text = "�̵��ӵ� : " + (truncatedNamS).ToString();
        }
    }

    void Update()
    {

    }
    // Update is called once per frame
    public void statsUpgrade(string buttonName)
    {
        //������ ���� ��ư�� ���� ��������Ʈ �Ҹ� �� ī����

        if (buttonName == "DamageStatButton")
        {
            if(SceneChangeManager.charactorNum == 2)
            {

                if (playerInfo.leeStatpoint > 0)
                {
                    playerInfo.leeStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.leeStatpoint).ToString();
                    playerInfo.LeeDamage += 0.7f;
                    playerInfo.leeDSpoint += 1;
                    GameObject.Find("StatCount_DText").GetComponent<Text>().text = (playerInfo.leeDSpoint).ToString() + "/100" + "\n +0.7";
                    GameObject.Find("DStatus").GetComponent<Text>().text = "���ݷ� : " + (Mathf.Round(playerInfo.LeeDamage * 10f) / 10f).ToString();
                }
                else if (playerInfo.leeStatpoint <= 0)
                {
                    playerInfo.leeStatpoint = 0;
                }
            }
            else if (SceneChangeManager.charactorNum == 3)
            {
                if (playerInfo.bockStatpoint > 0)
                {
                    playerInfo.bockStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.bockStatpoint).ToString();
                    playerInfo.BockDamage += 0.7f;
                    playerInfo.bockDSpoint += 1;
                    GameObject.Find("StatCount_DText").GetComponent<Text>().text = (playerInfo.bockDSpoint).ToString() + "/100" + "\n +0.7";
                    GameObject.Find("DStatus").GetComponent<Text>().text = "���ݷ� : " + (Mathf.Round(playerInfo.BockDamage * 10f) / 10f).ToString();
                }
                else if (playerInfo.bockStatpoint <= 0)
                {
                    playerInfo.bockStatpoint = 0;
                }
            }
            else if(SceneChangeManager.charactorNum == 4)
            {
                if (playerInfo.namStatpoint > 0)
                {
                    playerInfo.namStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.namStatpoint).ToString();
                    playerInfo.NamDamage += 1;
                    playerInfo.namDSpoint += 1;
                    GameObject.Find("StatCount_DText").GetComponent<Text>().text = (playerInfo.namDSpoint).ToString() + "/100" + "\n +1.0";
                    GameObject.Find("DStatus").GetComponent<Text>().text = "���ݷ� : " + (Mathf.Round(playerInfo.NamDamage * 10f) / 10f).ToString();
                }
                else if (playerInfo.namStatpoint <= 0)
                {
                    playerInfo.namStatpoint = 0;
                }
            }
        }
        else if (buttonName == "HpStatButton")
        {
            if (SceneChangeManager.charactorNum == 2)
            {
                if (playerInfo.leeStatpoint > 0)
                {
                    playerInfo.leeStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.leeStatpoint).ToString();
                    playerInfo.LeeHealth += 45;
                    playerInfo.leeHSpoint += 1;
                    GameObject.Find("StatCount_HText").GetComponent<Text>().text = (playerInfo.leeHSpoint).ToString() + "/100" + "\n +45";
                    GameObject.Find("HStatus").GetComponent<Text>().text = "ü�� : " + (playerInfo.LeeHealth).ToString();
                }
                else if (playerInfo.leeStatpoint <= 0)
                {
                    playerInfo.leeStatpoint = 0;
                }
            }
            else if (SceneChangeManager.charactorNum == 3)
            {
                if (playerInfo.bockStatpoint > 0)
                {
                    playerInfo.bockStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.bockStatpoint).ToString();
                    playerInfo.BockHealth += 30;
                    playerInfo.bockHSpoint += 1;
                    GameObject.Find("StatCount_HText").GetComponent<Text>().text = (playerInfo.bockHSpoint).ToString() + "/100" + "\n +30";
                    GameObject.Find("HStatus").GetComponent<Text>().text = "ü�� : " + (playerInfo.BockHealth).ToString();
                }
                else if (playerInfo.bockStatpoint <= 0)
                {
                    playerInfo.bockStatpoint = 0;
                }
            }
            else if (SceneChangeManager.charactorNum == 4)
            {
                if (playerInfo.namStatpoint > 0)
                {
                    playerInfo.namStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.namStatpoint).ToString();
                    playerInfo.NamHealth += 30;
                    playerInfo.namHSpoint += 1;
                    GameObject.Find("StatCount_HText").GetComponent<Text>().text = (playerInfo.namHSpoint).ToString() + "/100" + "\n +30";
                    GameObject.Find("HStatus").GetComponent<Text>().text = "ü�� : " + (playerInfo.NamHealth).ToString();
                }
                else if (playerInfo.namStatpoint <= 0)
                {
                    playerInfo.namStatpoint = 0;
                }
            }
        }
        else if (buttonName == "SpeedStatButton")
        {
            if (SceneChangeManager.charactorNum == 2)
            {
                if (playerInfo.leeStatpoint > 0)
                {
                    playerInfo.leeStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.leeStatpoint).ToString();
                    playerInfo.LeeSpeed += 0.1f;
                    playerInfo.leeSSpoint += 1;
                    GameObject.Find("StatCount_SText").GetComponent<Text>().text = (playerInfo.leeSSpoint).ToString() + "/100" + "\n +0.1";
                    GameObject.Find("SStatus").GetComponent<Text>().text = "�̵��ӵ� : " + (Mathf.Round(playerInfo.LeeSpeed * 10f) / 10f).ToString();
                }
                else if (playerInfo.leeStatpoint <= 0)
                {
                    playerInfo.leeStatpoint = 0;
                }
            }
            else if(SceneChangeManager.charactorNum == 3)
            {
                if (playerInfo.bockStatpoint > 0)
                {
                    playerInfo.bockStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.bockStatpoint).ToString();
                    playerInfo.BockSpeed += 0.2f;
                    playerInfo.bockSSpoint += 1;
                    GameObject.Find("StatCount_SText").GetComponent<Text>().text = (playerInfo.bockSSpoint).ToString() + "/100" + "\n +0.2";
                    GameObject.Find("SStatus").GetComponent<Text>().text = "�̵��ӵ� : " + (Mathf.Round(playerInfo.BockSpeed * 10f) / 10f).ToString();
                }
                else if (playerInfo.bockStatpoint <= 0)
                {
                    playerInfo.bockStatpoint = 0;
                }
            }
            else if (SceneChangeManager.charactorNum == 4)
            {
                if (playerInfo.namStatpoint > 0)
                {
                    playerInfo.namStatpoint -= 1;
                    GameObject.Find("statPoint").GetComponent<Text>().text = "��������Ʈ : " + (playerInfo.namStatpoint).ToString();
                    playerInfo.NamSpeed += 0.1f;
                    playerInfo.namSSpoint += 1;
                    GameObject.Find("StatCount_SText").GetComponent<Text>().text = (playerInfo.namSSpoint).ToString() + "/100" + "\n +0.1";
                    GameObject.Find("SStatus").GetComponent<Text>().text = "�̵��ӵ� : " + (Mathf.Round(playerInfo.NamSpeed * 10f) / 10f).ToString();
                }
                else if (playerInfo.namStatpoint <= 0)
                {
                    playerInfo.namStatpoint = 0;
                }
            }
        }
    }
}
