using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScene : MonoBehaviour
{
    public void BackSceneBtn()
    {
        if (this.gameObject.name == "BackButton")
        {
            SceneManager.LoadScene("CharactorPage");
        }
        else if (this.gameObject.name == "SSPBtn")
        {
            SceneManager.LoadScene("StageSelectPage");
        }
        else if(this.gameObject.name == "StageBackBtn")
        {
            switch (SceneChangeManager.charactorNum)
            {
                case 2:
                    SceneManager.LoadScene("MainPage");
                    break;
                case 3:
                    SceneManager.LoadScene("MainPage");
                    break;
                case 4:
                    SceneManager.LoadScene("MainPage");
                    break;
            }
        }
    }
}
