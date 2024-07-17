using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeoutEffect : MonoBehaviour
{
    public Image Fadeout;

    public void Awake()
    {
        Fadeout = GetComponent<Image>();
    }

    public void FadeoutSet()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Color color = Fadeout.color;

            if (color.a < 1)
            {
                color.a += Time.deltaTime;
            }

            Fadeout.color = color;
        }
    }
}
