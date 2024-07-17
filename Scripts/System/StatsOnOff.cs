using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StatsOnOff : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("StatsGroup").SetActive(false);
    }
    public void SOnOff(GameObject obj)
    {
        if (obj.gameObject.name == "StatsGroup")
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
            }
            else if (obj.activeSelf == true)
            {
                obj.SetActive(false);
            }
        }
    }
}
