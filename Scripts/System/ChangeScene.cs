using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ChangeScene : MonoBehaviour
{
    public void buttonclick(GameObject other)
    {
        if (other.gameObject.name == "Stage1") SceneManager.LoadScene("ForestScene");
        else if(other.gameObject.name == "Stage2") SceneManager.LoadScene("DessertScene");
        else if (other.gameObject.name == "Stage3") SceneManager.LoadScene("SnowScene");
        else if (other.gameObject.name == "Stage4") SceneManager.LoadScene("CaveScene");
        else if (other.gameObject.name == "Stage5") SceneManager.LoadScene("MagmaScene");
        else SceneManager.LoadScene("MainPage");
    }
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "LeeBtn":
                SceneManager.LoadScene("MainPage");
                break;
            case "BockBtn":
                SceneManager.LoadScene("MainPage");
                break;
            case "NamBtn":
                SceneManager.LoadScene("MainPage");
                break;
            case "StageButton":
                SceneManager.LoadScene("StageSelectPage");
                break;
            case "StartButton":
                if (SceneChangeManager.selectNum == 11)
                {
                    SceneManager.LoadScene("1-1Map");
                }
                else if (SceneChangeManager.selectNum == 12)
                {
                    SceneManager.LoadScene("1-2Map");
                }
                else if (SceneChangeManager.selectNum == 13)
                {
                    SceneManager.LoadScene("1-3Map");
                }
                else if (SceneChangeManager.selectNum == 14)
                {
                    SceneManager.LoadScene("1-4Map");
                }
                else if (SceneChangeManager.selectNum == 15)
                {
                    SceneManager.LoadScene("1-5Map");
                }
                else if (SceneChangeManager.selectNum == 21)
                {
                    SceneManager.LoadScene("2-1Map");
                }
                else if (SceneChangeManager.selectNum == 22)
                {
                    SceneManager.LoadScene("2-2Map");
                }
                else if (SceneChangeManager.selectNum == 23)
                {
                    SceneManager.LoadScene("2-3Map");
                }
                else if (SceneChangeManager.selectNum == 24)
                {
                    SceneManager.LoadScene("2-4Map");
                }
                else if (SceneChangeManager.selectNum == 25)
                {
                    SceneManager.LoadScene("2-5Map");
                }
                else if (SceneChangeManager.selectNum == 31)
                {
                    SceneManager.LoadScene("3-1Map");
                }
                else if (SceneChangeManager.selectNum == 32)
                {
                    SceneManager.LoadScene("3-2Map");
                }
                else if (SceneChangeManager.selectNum == 33)
                {
                    SceneManager.LoadScene("3-3Map");
                }
                else if (SceneChangeManager.selectNum == 34)
                {
                    SceneManager.LoadScene("3-4Map");
                }
                else if (SceneChangeManager.selectNum == 35)
                {
                    SceneManager.LoadScene("3-5Map");
                }
                else if (SceneChangeManager.selectNum == 41)
                {
                    SceneManager.LoadScene("4-1Map");
                }
                else if (SceneChangeManager.selectNum == 42)
                {
                    SceneManager.LoadScene("4-2Map");
                }
                else if (SceneChangeManager.selectNum == 43)
                {
                    SceneManager.LoadScene("4-3Map");
                }
                else if (SceneChangeManager.selectNum == 44)
                {
                    SceneManager.LoadScene("4-4Map");
                }
                else if (SceneChangeManager.selectNum == 45)
                {
                    SceneManager.LoadScene("4-5Map");
                }
                else if (SceneChangeManager.selectNum == 51)
                {
                    SceneManager.LoadScene("5-1Map");
                }
                else if (SceneChangeManager.selectNum == 52)
                {
                    SceneManager.LoadScene("5-2Map");
                }
                else if (SceneChangeManager.selectNum == 53)
                {
                    SceneManager.LoadScene("5-3Map");
                }
                else if (SceneChangeManager.selectNum == 54)
                {
                    SceneManager.LoadScene("5-4Map");
                }
                else if (SceneChangeManager.selectNum == 55)
                {
                    SceneManager.LoadScene("5-5Map");
                }
                break;
            default:
                if (SceneChangeManager.charactorNum == 2)
                {
                    SceneManager.LoadScene("MainPage");
                }
                else if (SceneChangeManager.charactorNum == 3)
                {
                    SceneManager.LoadScene("MainPage");
                }
                else if (SceneChangeManager.charactorNum == 4)
                {
                    SceneManager.LoadScene("MainPage");
                }
                break;
        }
    }
}
