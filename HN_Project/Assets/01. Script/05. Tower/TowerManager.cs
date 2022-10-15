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
        
        GetNomalTowerStat();
        GetPoisonTowerStat();
        GetFireTowerStat();
        GetSlowTowerStat();
    }

    #region Nomal Tower
    [Header("Nomal Attack")]
    public static float Nomal_Attack_Power;
    public static float Nomal_Attack_Speed;
    public static float Nomal_Attack_Pierce;
    public static float Nomal_Attack_Range;

    [Header("Nomal Target")]
    public static int Nomal_Target_Multi;
    public static int Nomal_Target_chain;

    [Header("Nomal Explosion")]
    public static float Nomal_Explosion_Range;
    private void GetNomalTowerStat()
    {
        TowerStatus NOMAL = TowerPrefab[0].GetComponent<TowerStatus>();
        Nomal_Attack_Power = NOMAL.GetAttack_Power();
        Nomal_Attack_Speed = NOMAL.GetAttack_Speed();
        Nomal_Attack_Pierce = NOMAL.GetAttack_Pierce();
        Nomal_Attack_Range = NOMAL.GetAttack_Range();

        Nomal_Target_Multi = NOMAL.GetTaget_Multi();
        Nomal_Target_chain = NOMAL.GetTaget_chain();
        
        Nomal_Explosion_Range = NOMAL.GetExplosion_Range();
    }

    #endregion

    #region Poison Tower
    [Header("\nPoison Attack")]
    public static float Poison_Attack_Power;
    public static float Poison_Attack_Speed;
    public static float Poison_Attack_Pierce;
    public static float Poison_Attack_Range;

    [Header("Poison Target")]
    public static int Poison_Target_Multi = 0;
    public static int Poison_Target_chain = 0;

    [Header("Poison Explosion")]
    public static float Poison_Explosion_Range;

    [Header("Poison")]
    public static float Poison_Time;

    private void GetPoisonTowerStat()
    {
        TowerStatus NOMAL = TowerPrefab[1].GetComponent<TowerStatus>();
        Poison_Attack_Power = NOMAL.GetAttack_Power();
        Poison_Attack_Speed = NOMAL.GetAttack_Speed();
        Poison_Attack_Pierce = NOMAL.GetAttack_Pierce();
        Poison_Attack_Range = NOMAL.GetAttack_Range();

        Poison_Target_Multi = NOMAL.GetTaget_Multi();
        Poison_Target_chain = NOMAL.GetTaget_chain();

        Poison_Explosion_Range = NOMAL.GetExplosion_Range();

        Poison_Time = NOMAL.GetPoison_Time();
    }

    #endregion

    #region Fire Tower
    [Header("\nFire Attack")]
    public static float Fire_Attack_Power;
    public static float Fire_Attack_Speed;
    public static float Fire_Attack_Pierce;
    public static float Fire_Attack_Range;

    [Header("Fire Target")]
    public static int Fire_Target_Multi = 0;
    public static int Fire_Target_chain = 0;

    [Header("Fire Explosion")]
    public static float Fire_Explosion_Range;

    [Header("Fire")]
    public static float Fire_TickCount;
    public static float Fire_TickSpeed;

    private void GetFireTowerStat()
    {
        TowerStatus NOMAL = TowerPrefab[1].GetComponent<TowerStatus>();
        Fire_Attack_Power = NOMAL.GetAttack_Power();
        Fire_Attack_Speed = NOMAL.GetAttack_Speed();
        Fire_Attack_Pierce = NOMAL.GetAttack_Pierce();
        Fire_Attack_Range = NOMAL.GetAttack_Range();

        Fire_Target_Multi = NOMAL.GetTaget_Multi();
        Fire_Target_chain = NOMAL.GetTaget_chain();

        Fire_Explosion_Range = NOMAL.GetExplosion_Range();

        Fire_TickCount = NOMAL.GetFire_TickCount();
        Fire_TickSpeed = NOMAL.GetFire_TickSpeed();
    }

    #endregion

    #region Slow Tower
    [Header("\nSlow Attack")]
    public static float Slow_Attack_Power;
    public static float Slow_Attack_Speed;
    public static float Slow_Attack_Pierce;
    public static float Slow_Attack_Range;

    [Header("Slow Target")]
    public static int Slow_Target_Multi = 0;
    public static int Slow_Target_chain = 0;

    [Header("Slow Explosion")]
    public static float Slow_Explosion_Range;

    [Header("Slow")]
    public static float Slow_Value;
    public static float Slow_Time;
    public static float Slow_Freezing_Value;
    public static float Slow_Freezing_Time;
    private void GetSlowTowerStat()
    {
        TowerStatus NOMAL = TowerPrefab[1].GetComponent<TowerStatus>();
        Slow_Attack_Power = NOMAL.GetAttack_Power();
        Slow_Attack_Speed = NOMAL.GetAttack_Speed();
        Slow_Attack_Pierce = NOMAL.GetAttack_Pierce();
        Slow_Attack_Range = NOMAL.GetAttack_Range();

        Slow_Target_Multi = NOMAL.GetTaget_Multi();
        Slow_Target_chain = NOMAL.GetTaget_chain();

        Slow_Explosion_Range = NOMAL.GetExplosion_Range();

        Slow_Value = NOMAL.GetSlow_Value();
        Slow_Time = NOMAL.GetSlow_Time();
        Slow_Freezing_Value = NOMAL.GetSlow_Freezing_Value();
        Slow_Freezing_Time = NOMAL.GetSlow_Freezing_Time();
    }

    #endregion

}

