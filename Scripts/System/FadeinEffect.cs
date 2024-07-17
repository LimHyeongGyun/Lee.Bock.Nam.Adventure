using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeinEffect : MonoBehaviour
{
    public Image Fadeout;

    public void Awake()
    {
        Fadeout = GetComponent<Image>();
    }

    public void Update()
    {
        Color color = Fadeout.color;

        if (color.a > 0)
        {
            color.a -= Time.deltaTime;
        }

        Fadeout.color = color;
    }
}
