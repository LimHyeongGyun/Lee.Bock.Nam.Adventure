using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    public static float currentTime = 0;
    public float startingTime ;

    [SerializeField] Text limitTimeText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        int curminutesInt = (int)currentTime / 60;
        int cursecondsInt = (int)currentTime % 60;

        currentTime -= 1 * Time.deltaTime;

        if (cursecondsInt == -1)
        {
            if(curminutesInt > 0)
            {
                curminutesInt -= 1;
                cursecondsInt += 59;
            }
            else if(curminutesInt == 0)
            {
                cursecondsInt += 59;
            }
        }

        if (curminutesInt <= 0 && cursecondsInt <= 0 && currentTime <= 0)
        {
            currentTime = 0;
            curminutesInt = 0;
            cursecondsInt = 0;
        }

        limitTimeText.color = Color.white;
        limitTimeText.text = "TimeLimit : " + curminutesInt.ToString("00") + ":" + cursecondsInt.ToString("00");
    }
}
