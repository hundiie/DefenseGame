using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    [Header("HP")]
    public float MaxHP;
    public float HP;

    [Header("MOVE")]
    public float MoveSpeed;

    [Header("Defense")]
    public float DefenseRank = 50;// 낮을수록 방어의 효율이 좋아짐
    public float Armor;
    public float Resistance;

    [Header("DROP")]
    public int MinGold;
    public int MaxGold;

    #region Get
    public float GetMaxHP() { return MaxHP; }
    public float GetHP() { return HP; }

    public float GetMoveSpeed() { return MoveSpeed; }
    
    public float GetArmor() { return Armor; }
    public float GetResistance() { return Resistance; }
    public float GetDefenseRank() { return DefenseRank; }



    public int GetMinGold() { return MinGold; }
    public int GetMaxGold() { return MaxGold; }
    #endregion
}
