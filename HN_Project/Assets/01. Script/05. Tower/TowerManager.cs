using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TOWER
{
    Nomal,
    Poison,
    Fire,
    Slow
}

public class TowerManager : MonoBehaviour
{
    #region �̱���
    //���ӸŴ����� �ν��Ͻ��� ��� ��������(static ���������� �����ϱ� ���� ����������� �ϰڴ�).
    //�� ���� ������ �Ŵ��� �ν��Ͻ��� �� instance�� ��� �༮�� �����ϰ� �� ���̴�.
    //������ ���� private����.
    private static TowerManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            //�� Ŭ���� �ν��Ͻ��� ź������ �� �������� instance�� ���ӸŴ��� �ν��Ͻ��� ������� �ʴٸ�, �ڽ��� �־��ش�.
            instance = this;

            //�� ��ȯ�� �Ǵ��� �ı����� �ʰ� �Ѵ�.
            //gameObject�����ε� �� ��ũ��Ʈ�� ������Ʈ�μ� �پ��ִ� Hierarchy���� ���ӿ�����Ʈ��� ��������, 
            //���� �򰥸� ������ ���� this�� �ٿ��ֱ⵵ �Ѵ�.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //���� �� �̵��� �Ǿ��µ� �� ������ Hierarchy�� SceneLoadManager�� ������ ���� �ִ�.
            //�׷� ��쿣 ���� ������ ����ϴ� �ν��Ͻ��� ��� ������ִ� ��찡 ���� �� ����.
            //�׷��� �̹� ���������� instance�� �ν��Ͻ��� �����Ѵٸ� �ڽ�(���ο� ���� SceneLoadManager)�� �������ش�.
            //���� ���� �߰��ϸ� ���� �����ϴ� ��ī����
            Destroy(this.gameObject);
        }
    }

    // �ٸ� Ŭ�������� ���� �����ϰ� ����ƽ ������Ƽ ����(�ν��Ͻ� ��������� �� ��ȯ�ϰ� ������ �װ� ��ȯ
    // private �� instance�� ���̸� �α����� �տ� �빮�ڷ� ��
    public static TowerManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion
    //======================= ���� �̱��� �ڵ� =======================
    
    
    public static GameObject[] TowerPrefab;

    public static int GetTowerPrefabCount(){ return TowerPrefab.Length; }
    public static GameObject GetTowerPrefab(int TowerNum){ return TowerPrefab[TowerNum]; }
    private void Start()
    {
        TowerPrefab = Resources.LoadAll<GameObject>("01. Prefab/02. Tower");

        for (int i = 0; i < TowerPrefab.Length; i++)
        {
            TowerStatus DataA = TowerPrefab[i].GetComponent<TowerStatus>();
            SetTowerStatData(DataA);
            TowerUpgread DataB = TowerPrefab[i].GetComponent<TowerUpgread>();
            SetTowerUpgreadData(DataB);
        }
    }

    //=========== TowerDATA ===========

    private static List<TowerStatus> TowerDataStat = new List<TowerStatus>();
    private static List<TowerUpgread> TowerDatabaUp = new List<TowerUpgread>();

    public void SetTowerStatData(TowerStatus towerStatus)
    {
        TowerDataStat.Add(towerStatus);
    }
    public void SetTowerUpgreadData(TowerUpgread towerUpgread)
    {
        TowerDatabaUp.Add(towerUpgread);
    }

    public static string GetTowerStatData(int TowerNum, int DataNum)
    {
        switch (DataNum)
        {
            case 0: return Convert.ToString(TowerDataStat[TowerNum].Type);
            case 1: return Convert.ToString(TowerDataStat[TowerNum].AttackType);

            case 2: return Convert.ToString(TowerDataStat[TowerNum].Money);

            case 3: return Convert.ToString(TowerDataStat[TowerNum].Attack_Power);
            case 4: return Convert.ToString(TowerDataStat[TowerNum].Attack_Speed);
            case 5: return Convert.ToString(TowerDataStat[TowerNum].Attack_Range);
            case 6: return Convert.ToString(TowerDataStat[TowerNum].Attack_Pierce);
            case 7: return Convert.ToString(TowerDataStat[TowerNum].Attack_Ex_Range);

            case 8: return Convert.ToString(TowerDataStat[TowerNum].Target_Multi);
            case 9: return Convert.ToString(TowerDataStat[TowerNum].Target_Chain);

            case 10: return Convert.ToString(TowerDataStat[TowerNum].Poison_Time);
            
            case 11: return Convert.ToString(TowerDataStat[TowerNum].Fire_TickCount);
            case 12: return Convert.ToString(TowerDataStat[TowerNum].Fire_TickSpeed);

            case 13: return Convert.ToString(TowerDataStat[TowerNum].Slow_Value);
            case 14: return Convert.ToString(TowerDataStat[TowerNum].Slow_Time);

            case 15: return Convert.ToString(TowerDataStat[TowerNum].Freezing_Value);
            case 16: return Convert.ToString(TowerDataStat[TowerNum].Freezing_Time);
            default: return null;
        }
    }

    public static string GetTowerUpgreadData(int TowerNum, int DataNum)
    {
        switch (DataNum)
        {
            case 0: return Convert.ToString(TowerDatabaUp[TowerNum].Money);
            case 1: return Convert.ToString(TowerDatabaUp[TowerNum].Attack_Power);
            case 2: return Convert.ToString(TowerDatabaUp[TowerNum].Attack_Speed);
            case 3: return Convert.ToString(TowerDatabaUp[TowerNum].Attack_Range);
            case 4: return Convert.ToString(TowerDatabaUp[TowerNum].Attack_Pierce);
            case 5: return Convert.ToString(TowerDatabaUp[TowerNum].Attack_Ex_Range);

            case 6: return Convert.ToString(TowerDatabaUp[TowerNum].Target_Multi);
            case 7: return Convert.ToString(TowerDatabaUp[TowerNum].Target_Chain);

            case 8: return Convert.ToString(TowerDatabaUp[TowerNum].Poison_Time);

            case 9: return Convert.ToString(TowerDatabaUp[TowerNum].Fire_TickCount);
            case 10: return Convert.ToString(TowerDatabaUp[TowerNum].Fire_TickSpeed);

            case 11: return Convert.ToString(TowerDatabaUp[TowerNum].Slow_Value);
            case 12: return Convert.ToString(TowerDatabaUp[TowerNum].Slow_Time);

            case 13: return Convert.ToString(TowerDatabaUp[TowerNum].Freezing_Value);
            case 14: return Convert.ToString(TowerDatabaUp[TowerNum].Freezing_Time);
            default: return null;
        }
    }
}