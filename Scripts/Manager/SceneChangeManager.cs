using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager
{
    public static int charactorNum;
    public static int selectNum;
    public static string mapnum;
    
    private static SceneChangeManager instance;

    public static SceneChangeManager Instance
    {
        get
        {
            if(null == instance)
            {
                instance = new SceneChangeManager();
            }
            return instance;
        }
    }
}
