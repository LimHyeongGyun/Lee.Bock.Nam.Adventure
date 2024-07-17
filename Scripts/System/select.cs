using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour
{
    void Start()
    {
        if (SceneChangeManager.charactorNum == 2)
        {
            GameObject.Find("Player_Lee").SetActive(true);
            GameObject.Find("Player_Bock").SetActive(false);
            GameObject.Find("Player_Nam").SetActive(false);
        }
        else if (SceneChangeManager.charactorNum == 3)
        {
            GameObject.Find("Player_Lee").SetActive(false);
            GameObject.Find("Player_Bock").SetActive(true);
            GameObject.Find("Player_Nam").SetActive(false);
        }
        else if (SceneChangeManager.charactorNum == 4)
        {
            GameObject.Find("Player_Lee").SetActive(false);
            GameObject.Find("Player_Bock").SetActive(false);
            GameObject.Find("Player_Nam").SetActive(true);
        }
    }
}
