using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // 인게임 내의 타워 스텟
    public int Level = 1;

    public int Type;
    public int AttackType;
    public int Money;

    public float Power;
    public float Speed;
    public float Range;
    public float Pierce;
    public float EX_Range;

    public int Multi;
    public int Chain;

    public float PoisonTime;

    public float FireCount;
    public float FireTime;

    public float IceValue;
    public float IceTime;

    public float FreezingValue;
    public float FreezingTime;


    private void Start()
    {
        Type = GetComponent<TowerStatus>().Type;
        AttackType = int.Parse(TowerManager.GetTowerStatData(0, 1));
        SetLevel(Level);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetLevel(Level);
        }
    }

    public void SetLevel(int Level)
    {
        for (int i = 0; i < 14; i++)
        {
            SetData(i, Level);
        }
    }

    private void SetData(int StatNum, int level)
    {
        switch (StatNum)
        {
            case 0: Power = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 1: Speed = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 2: Range = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 3: Pierce = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 4: EX_Range = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 5: Multi = int.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (int.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 6: Chain = int.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (int.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 7: PoisonTime = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 8: FireCount = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 9: FireTime = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) - (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 10: IceValue = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 11: IceTime = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 12: FreezingValue = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            case 13: FreezingTime = float.Parse(TowerManager.GetTowerStatData(Type, StatNum + 3)) + (float.Parse(TowerManager.GetTowerUpgreadData(Type, StatNum + 1)) * (level - 1)); return;
            default: break;
        }
    }

    // 버프관련
}
