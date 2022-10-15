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

