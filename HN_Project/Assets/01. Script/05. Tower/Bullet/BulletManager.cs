using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float Power;
    private float Range;
    private float Pierce;
    private float EX_Range;

    private int Chain;

    private float PoisonTime;

    private float FireCount;
    private float FireTime;

    private float SlowValue;
    private float SlowTime;

    private float FreezingValue;
    private float FreezingTime;

    void SetBullet(float power, float range, float pierce, float ex_range, int chain, float po_time, float fi_count, float fi_time, float ice_value, float ice_time, float fre_value, float fre_time)
    {
        Power = power;
        Range = range;
        Pierce = pierce;
        EX_Range = ex_range;
        Chain = chain;

        PoisonTime = po_time;
        
        FireCount = fi_count;
        FireTime = fi_time;

        SlowValue = ice_value;
        SlowTime = ice_time;

        FreezingValue = fre_value;
        FreezingTime = fre_time;
    }
}
