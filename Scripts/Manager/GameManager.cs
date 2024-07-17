using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public enum State { Start, Playing, Pause, GameClear, GameOver };

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ingamePanel;
    public GameObject overPanel;
    public GameObject clearPanel;

    public Player player;
    public PoolManager pool;

    public Image Fadeout;
    public static State gameState;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameState = State.Playing;
    }
    
    public void Update()
    {
        switch (gameState)
        {
            case State.Start:               
                break;
            case State.Playing:
                ingamePanel.SetActive(true);
                clearPanel.SetActive(false);
                overPanel.SetActive(false);
                break;
            case State.Pause:
                break;
            case State.GameClear:
                ingamePanel.SetActive(false);
                if (SceneChangeManager.selectNum == 55)
                {
                    Color color = Fadeout.color;

                    if (color.a < 1)
                    {
                        color.a += Time.deltaTime;
                        if (color.a >= 1)
                        {
                            SceneManager.LoadScene("Ending");
                        }
                    }

                    Fadeout.color = color;
                }
                else
                {
                    clearPanel.SetActive(true);
                }               
                break;
            case State.GameOver:
                ingamePanel.SetActive(false);
                overPanel.SetActive(true);
                break;
            default:
                break;
        }
    }
}

