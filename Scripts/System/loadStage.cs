using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class loadStage : MonoBehaviour
{
   public GameObject StartButton;

    void Start()
    {
        StartButton.GetComponentInChildren<Text>().text =
                "Stage  " + SceneChangeManager.mapnum;
    }
}
