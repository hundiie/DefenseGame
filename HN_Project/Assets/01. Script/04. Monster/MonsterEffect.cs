using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEffect : MonoBehaviour
{
    private MonsterStatus _MonsterStatus;
    private MonsterHealth _MonsterHealth;
    private MonsterNav _MonsterNav;

    private Renderer _Renderer;
    private Color NomalColor;
    
    private float Armor;
    private float Resistance;
    private float Defense_Rank;
    private float P_Armor;
    private float P_Resistance;

    [Header("Die")]
    public bool Die;

    [Header("Poison")]
    public int PoisonStack;
    public bool Poison;

    [Header("Fire")]
    public int FireStack;
    public bool Fire;

    [Header("Slow")]
    public int SlowStack;
    public bool Slow;

    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        _MonsterHealth = GetComponent<MonsterHealth>();
        _MonsterNav = GetComponent<MonsterNav>();

        _Renderer = gameObject.GetComponent<Renderer>();
        NomalColor = _Renderer.material.color;

        Armor = _MonsterStatus.GetArmor();
        Resistance = _MonsterStatus.GetResistance();
        Defense_Rank = _MonsterStatus.GetDefenseRank();
    }
    private void Update()
    {
        if (_MonsterHealth.GetDie() && !Die)
        {
            Die = true;
            AddDie();
        }
        P_Armor = Defense_Rank / (Defense_Rank + Armor);
        P_Resistance = Defense_Rank / (Defense_Rank + Resistance);

        //---------test----------
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddPhysicsHit(0.1f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddPoison(5, 5);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddFire(5, 1, 5);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddSlow(10, 50, 5);
        }
        
    }

    private void ChangeColor(Color color)
    {
        _Renderer.material.color = color;
    }

    #region Die
    public void AddDie()
    {
        StopAllCoroutines();
        StartCoroutine(_AddDie());
    }
    private IEnumerator _AddDie()
    {
        
        _MonsterNav.SetMoveSpeed(0);
        ChangeColor(Color.black);

        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            Color This = _Renderer.material.color;
            This.a = i;
            _Renderer.material.color = This;
            yield return null;
        }

        Destroy(gameObject);
    }
    #endregion

    #region PhysicsDanage
    /// <summary>
    /// 물리 데미지 (기본 데미지)
    /// </summary>
    /// <param name="Damage">받는 데미지</param>
    public void AddPhysicsHit(float Damage)
    {
        if (_MonsterHealth.GetDie()) { return; }
        _MonsterHealth.AddHP(-Damage * P_Armor);
    }
    #endregion

    #region MagicDanage
    /// <summary>
    /// 마법 데미지 (기본 데미지)
    /// </summary>
    /// <param name="Damage">받는 데미지</param>
    public void AddMagicHit(float Damage)
    {
        if (_MonsterHealth.GetDie()){ return; }
        _MonsterHealth.AddHP(-Damage * P_Resistance);
    }
    #endregion

    #region TrueDanage
    /// <summary>
    /// 고정 데미지 (기본 데미지)
    /// </summary>
    /// <param name="Damage">받는 데미지</param>
    public void AddTrueHit(float Damage)
    {
        if (_MonsterHealth.GetDie()) { return; }
        _MonsterHealth.AddHP(-Damage);
    }
    #endregion

    #region Poison
    /// <summary>
    /// 독 데미지 (지속적인 마법데미지, 중첩 O)
    /// </summary>
    /// <param name="Damage">초당 독 데미지</param>
    /// <param name="Time">독 지속시간</param>
    public void AddPoison(float Damage, float Time)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddPoison(Damage, Time));
    }
    private IEnumerator _AddPoison(float SecondDamage, float PoisonTime)
    {
        PoisonStack += 1;

        Poison = true;
        ChangeColor(Color.magenta);
    
        float Delta = 0;
        while (Delta < PoisonTime)
        {
            Delta += Time.deltaTime;
            AddMagicHit(Time.deltaTime * SecondDamage);
            yield return null;
        }

        PoisonStack -= 1;
        if (PoisonStack == 0)
        {
            Poison = false;
            ChangeColor(NomalColor);
        }
    }
    #endregion

    #region Fire

    /// <summary>
    /// 화염 데미지 (틱 마다 마법데미지, 중첩 O)
    /// </summary>
    /// <param name="TickDamage">틱 마다 받는 데미지</param>
    /// <param name="TickSpeed">틱 속도</param>
    /// <param name="Tick">틱 개수</param>
    public void AddFire(float TickDamage, float TickSpeed, int Tick)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddFire(TickDamage, TickSpeed, Tick));
    }
    private IEnumerator _AddFire(float TickDamage, float TickSpeed, int Tick)
    {
        FireStack += 1;

        Fire = true;
        ChangeColor(Color.red);
        
        for (int i = 0; i < Tick - 1; i++)
        {
            AddMagicHit(TickDamage);
            yield return new WaitForSeconds(TickSpeed);
        }
        AddMagicHit(TickDamage);

        FireStack -= 1;
        if (FireStack == 0)
        {
            Fire = false;
            ChangeColor(NomalColor);
        }
    }
    #endregion

    #region Slow
    public void AddSlow(float Damage, float Slow, float SlowTime)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddSlow(Damage, Slow, SlowTime));
    }
    private IEnumerator _AddSlow(float Damage, float SlowP, float SlowTime)
    {
        SlowStack += 1;
        AddPhysicsHit(Damage);
        Slow = true;
        ChangeColor(Color.blue);
    
        _MonsterNav.SetMoveSpeed((_MonsterStatus.GetMoveSpeed() / 100) * SlowP);

        yield return new WaitForSeconds(SlowTime);

        SlowStack -= 1;
        if (PoisonStack == 0)
        {
            Slow = false;
            ChangeColor(NomalColor);
            _MonsterNav.SetMoveSpeed(_MonsterStatus.GetMoveSpeed());
        }
    }
    #endregion

}
