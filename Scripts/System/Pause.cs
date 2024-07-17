using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject setGroup; 
     
    bool pauseActive;   

    void Start()
    {
        setGroup.SetActive(false);
    }
    
    public void PauseGame()
    {
        if (pauseActive)
        {
            Time.timeScale = 1;
            setGroup.SetActive(false);
            pauseActive = false;
        }
        else
        {
            Time.timeScale = 0;
            setGroup.SetActive(true); //����â setActive(true)�� ������ֱ�
            pauseActive = true;
        }
    }   
}

