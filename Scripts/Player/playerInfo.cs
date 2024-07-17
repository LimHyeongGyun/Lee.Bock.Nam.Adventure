using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo
{
    public static float LeeDamage = 30.0f;
    public static float LeeSpeed = 8.0f;
    public static int LeeHealth = 600;
    public static int LeeEXP = 0;
    public static int LeeLv = 1;
    public static int leeStatpoint = 5;
    public static int leeDSpoint = 0;
    public static int leeSSpoint = 0;
    public static int leeHSpoint = 0;

    public static float BockDamage = 15.0f;
    public static float BockSpeed = 9.0f;
    public static int BockHealth = 350;
    public static int BockEXP = 0;
    public static int BockLv = 1;
    public static int bockStatpoint = 5;
    public static int bockDSpoint = 0;
    public static int bockSSpoint = 0;
    public static int bockHSpoint = 0;

    public static float NamDamage = 25.0f;
    public static float NamSpeed = 6.5f;
    public static int NamHealth = 400;
    public static int NamEXP = 0;
    public static int NamLv = 1;
    public static int namStatpoint = 5;
    public static int namDSpoint = 0;
    public static int namSSpoint = 0;
    public static int namHSpoint = 0;

    private static playerInfo instance;

    public static playerInfo Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new playerInfo();
            }
            return instance;
        }
    }
}

