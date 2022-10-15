using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatus : MonoBehaviour
{
    [Header("Type")]
    public TOWER TowerType;
    public DamageType DamageType;
    public TOWER GetTowerType() { return TowerType; }
    public string GetTowerName() { return TowerType.ToString() + "Tower"; }
    public string GetDamageType() { return DamageType.ToString(); }
    #region Attack
    [Header("Attack")]
    public float Attack_Power;
    public float Attack_Speed;
    public float Attack_Pierce;
    public float Attack_Range;
    
    public float GetAttack_Power() { return Attack_Power; }
    public float GetAttack_Speed() { return Attack_Speed; }
    public float GetAttack_Pierce() { return Attack_Pierce; }
    public float GetAttack_Range() { return Attack_Range; }
    public void SetAttack_Power(float Power) { Attack_Power = Power; }
    public void SetAttack_Speed(float Speed) { Attack_Speed = Speed; }
    public void SetAttack_Pierce(float Pierce) { Attack_Pierce = Pierce; }
    public void SetAttack_Range(float Range) { Attack_Range = Range; }

    #endregion

    #region Target
    [Header("Target")]
    public int Target_Multi = 0;
    public int Target_chain = 0;
    public int GetTaget_Multi() { return Target_Multi; }
    public int GetTaget_chain() { return Target_chain; }
    public void SetTarget_Multi(int Multi) { Target_Multi = Multi; }
    public void SetTarget_chain(int chain) { Target_chain = chain; }

    #endregion

    #region Explosion
    [Header("Explosion")]
    public float Explosion_Range;
    public float GetExplosion_Range() { return Explosion_Range; }
    public void SetExplosion_Range(int Range) { Explosion_Range = Range; }

    #endregion

    //---------- Type -----------

    #region Poison

    [Header("Poison")]
    public float Poison_Time;
    public float GetPoison_Time() { return Poison_Time; }
    public void SetPoison_Time(int Time) { Poison_Time = Time; }

    #endregion

    #region Fire

    [Header("Fire")]
    public float Fire_TickCount;
    public float Fire_TickSpeed;
    public float GetFire_TickCount() { return Fire_TickCount; }
    public float GetFire_TickSpeed() { return Fire_TickSpeed; }
    public void SetFire_TickCount(int TickCount) { Fire_TickCount = TickCount; }
    public void SetFire_TickSpeed(int TickSpeed) { Fire_TickSpeed = TickSpeed; }

    #endregion

    #region Slow

    [Header("Slow")]
    public float Slow_Value;
    public float Slow_Time;
    public float Slow_Freezing_Value;
    public float Slow_Freezing_Time;
    public float GetSlow_Value() { return Slow_Value; }
    public float GetSlow_Time() { return Slow_Time; }
    public float GetSlow_Freezing_Time() { return Slow_Freezing_Time; }
    public float GetSlow_Freezing_Value() { return Slow_Freezing_Value; }
    public void SetSlow_Value(float Value) { Slow_Value = Value; }
    public void SetSlow_Time(float Time) { Slow_Time = Time; }
    public void SetSlow_Freezing_Value(float Freezing_Value) { Slow_Freezing_Value = Freezing_Value; }
    public void SetSlow_Freezing_Time(float Freezing_Time) { Slow_Freezing_Time = Freezing_Time; }

    #endregion

    //public float Upgread_Attack_Power;
    //public float Upgread_Attack_Speed;
    //public float Upgread_Attack_Pierce;
    //public float Upgread_Attack_Range;



}
