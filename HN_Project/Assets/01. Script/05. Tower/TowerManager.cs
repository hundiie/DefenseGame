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
    #region 싱글톤
    //게임매니저의 인스턴스를 담는 전역변수(static 변수이지만 이해하기 쉽게 전역변수라고 하겠다).
    //이 게임 내에서 매니저 인스턴스는 이 instance에 담긴 녀석만 존재하게 할 것이다.
    //보안을 위해 private으로.
    private static TowerManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            //이 클래스 인스턴스가 탄생했을 때 전역변수 instance에 게임매니저 인스턴스가 담겨있지 않다면, 자신을 넣어준다.
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            //gameObject만으로도 이 스크립트가 컴포넌트로서 붙어있는 Hierarchy상의 게임오브젝트라는 뜻이지만, 
            //나는 헷갈림 방지를 위해 this를 붙여주기도 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 SceneLoadManager가 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신(새로운 씬의 SceneLoadManager)을 삭제해준다.
            //지가 지를 발견하면 지를 삭제하는 메카니즘
            Destroy(this.gameObject);
        }
    }

    // 다른 클래스에서 쉽게 접근하게 스태틱 프로퍼티 생성(인스턴스 비어있으면 널 반환하고 있으면 그걸 반환
    // private 의 instance와 차이를 두기위해 앞에 대문자로 씀
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
    //======================= 위쪽 싱글톤 코드 =======================
    
    
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