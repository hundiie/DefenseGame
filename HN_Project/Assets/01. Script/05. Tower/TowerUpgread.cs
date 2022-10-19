using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgread : MonoBehaviour
{
    [Header("Money")]
    public int Money =0;

    [Header("Attack")]
    public float Attack_Power = 0;
    public float Attack_Speed = 0;
    public float Attack_Range = 0;
    public float Attack_Pierce = 0;
    public float Attack_Ex_Range = 0;

    [Header("Taget")]
    public int Target_Multi = 0;
    public int Target_Chain = 0;

    [Header("Poison")]
    public float Poison_Time = 0;

    [Header("Fire")]
    public float Fire_TickCount = 0;
    public float Fire_TickSpeed = 0;

    [Header("Slow")]
    public float Slow_Value = 0;
    public float Slow_Time = 0;

    [Header("Freezing")]
    public float Freezing_Value = 0;
    public float Freezing_Time = 0;

    public TowerUpgread(int money, float power, float speed, float range, float pierce, float ex_renge, int multi, int chain, float P_time, float F_Tcount, float F_Tspeed, float S_value, float S_time, float FIZ_value, float FIZ_time)
    {
        Money = money;
        Attack_Power = power;
        Attack_Speed = speed;
        Attack_Range = range;
        Attack_Pierce = pierce;
        Attack_Ex_Range = ex_renge;

        Target_Multi = multi;
        Target_Chain = chain;

        Poison_Time = P_time;

        Fire_TickCount = F_Tcount;
        Fire_TickSpeed = F_Tspeed;

        Slow_Value = S_value;
        Slow_Time = S_time;

        Freezing_Value = FIZ_value;
        Freezing_Time = FIZ_time;
    }
}
