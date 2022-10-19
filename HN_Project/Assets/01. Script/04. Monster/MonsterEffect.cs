using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DamageType
{
    Physics,
    Magic,
    True
}

public class MonsterEffect : MonoBehaviour
{
    //float s = 2;
    //1 / s 초

    private MonsterStatus _MonsterStatus;
    private MonsterHealth _MonsterHealth;
    private MonsterNav _MonsterNav;
    // 색 관련
    private Renderer _Renderer;
    private Color NomalColor;

    // 방어 관련
    private float Armor;
    private float Resistance;
    private float DefenseValue;

    // 데미지 관련
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

    [Header("Freezing")]
    public int FreezingStack;
    public bool Freezing;

    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        _MonsterHealth = GetComponent<MonsterHealth>();
        _MonsterNav = GetComponent<MonsterNav>();

        _Renderer = gameObject.GetComponent<Renderer>();
        NomalColor = _Renderer.material.color;

        Armor = _MonsterStatus.GetArmor();
        Resistance = _MonsterStatus.GetResistance();
        DefenseValue = _MonsterStatus.GetDefenseValue();
    }

    private void Update()
    {
        //테스트 용도
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddEffect_Nomal(DamageType.True, 1, 5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddEffect_Poison(DamageType.Physics, 0, 5, 5);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            AddEffect_Fire(DamageType.Magic, 0, 5, 1, 5);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddEffect_Slow(DamageType.True, 0, 10, 50, 5);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            AddEffect_Freezing(DamageType.True, 0, 10, 3);
        }
    }

    private void ChangeColor(Color color)
    { _Renderer.material.color = color; }

    // -------------------- 데미지 주는곳 --------------------
    #region AddDamage

    public void AddDamage(DamageType damageType, float Piercing, float Damage) // 데미지 넣을때 사용
    {
        float TakeDamage = GetTakeDamage(damageType, Piercing, Damage);
        _MonsterHealth.AddHP(-TakeDamage);
        if (0 >= _MonsterHealth.GetHP() && !Die)
        { AddDamage_Die(); }
        return;
    }

    private float TakeDamage(float Defense)
    { return DefenseValue / (DefenseValue + Defense); }
    private float GetTakeDamage(DamageType damageType, float Piercing, float Damage)
    {
        switch (damageType)
        {
            case DamageType.Physics:
                {
                    float Take = Armor - Piercing;
                    if (Take < 0) { Take = 0; }
                    return Damage * TakeDamage(Take);
                }
            case DamageType.Magic:
                {
                    float Take = Resistance - Piercing;
                    if (Take < 0) { Take = 0; }
                    return Damage * TakeDamage(Take);
                }
            case DamageType.True:
                {
                    return Damage;
                };
            default:
                break;
        }
        return 0;
    }

    #endregion
    // -------------------- 죽음 --------------------
    #region Die

    public void AddDamage_Die()
    {
        Die = true;
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
    // -------------------- 노말 효과 --------------------
    #region Nomal

    public void AddEffect_Nomal(DamageType damageType, float Piercing, float Damage)
    {
        AddDamage(damageType, Damage, Piercing);
    }

    #endregion
    // -------------------- 독 효과 --------------------
    #region Poison

    public void AddEffect_Poison(DamageType damageType, float Piercing, float SecondDamage, float PoisonTime)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddPoison(damageType, Piercing, SecondDamage, PoisonTime));
    }
    private IEnumerator _AddPoison(DamageType damageType, float Piercing, float SecondDamage, float PoisonTime)
    {
        PoisonStack += 1;

        Poison = true;
        // 독 효과
        ChangeColor(Color.magenta);

        float Delta = 0;
        while (Delta < PoisonTime)
        {
            Delta += Time.deltaTime;
            AddDamage(damageType, Piercing, Time.deltaTime * SecondDamage);
            yield return null;
        }

        PoisonStack -= 1;
        if (PoisonStack == 0)
        {
            Poison = false;
            // 독 효과 제거
            ChangeColor(NomalColor);
        }
    }
    public bool GetStatePoison(){ return Poison; }
    public int GetStackPoison() { return PoisonStack; }
    #endregion
    // -------------------- 불 효과 --------------------
    #region Fire
    private List<float> FireDamage;
    public void AddEffect_Fire(DamageType damageType, float Piercing, float TickDamage, float TickSpeed, int TickCount)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddFire(damageType, Piercing, TickDamage, TickSpeed, TickCount));
    }
    private IEnumerator _AddFire(DamageType damageType, float Piercing, float TickDamage, float TickSpeed, int TickCount)
    {
        FireStack += 1;

        Fire = true;
        // 화염 효과
        ChangeColor(Color.red);

        for (int i = 0; i < TickCount - 1; i++)
        {
            AddDamage(damageType, Piercing, TickDamage);
            yield return new WaitForSeconds(TickSpeed);
        }
        AddDamage(damageType, Piercing, TickDamage);
        FireStack -= 1;
        if (FireStack == 0)
        {
            Fire = false;
            // 화염 효과 제거
            ChangeColor(NomalColor);
        }
    }
    public bool GetStateFire() { return Fire; }
    public int GetStackFire() { return FireStack; }
    #endregion
    // -------------------- 슬로우 효과 --------------------
    #region Slow

    public void AddEffect_Slow(DamageType damageType, float Piercing, float Damage, float Slow_Per, float SlowTime)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddSlow(damageType, Piercing, Damage, Slow_Per, SlowTime));
    }
    private IEnumerator _AddSlow(DamageType damageType, float Piercing, float Damage, float Slow_Per, float SlowTime)
    {
        SlowStack += 1;

        Slow = true;
        _MonsterNav.SetMoveSpeed((_MonsterStatus.GetMoveSpeed() / 100) * Slow_Per);
        AddDamage(damageType, Piercing, Damage);
        // 슬로우 효과
        ChangeColor(Color.blue);

        yield return new WaitForSeconds(SlowTime);

        SlowStack -= 1;
        if (SlowStack <= 0)
        {
            Slow = false;
            _MonsterNav.SetMoveSpeed(_MonsterStatus.GetMoveSpeed());
            // 슬로우 효과 제거
            ChangeColor(NomalColor);
        }
    }
    public bool GetStateSlow() { return Slow; }
    public int GetStackSlow() { return SlowStack; }
    #endregion
    // -------------------- 동결 효과 --------------------
    #region Freezing

    public void AddEffect_Freezing(DamageType damageType, float Piercing, float Damage, float FreezingTime)
    {
        if (_MonsterHealth.GetDie()) { return; }
        StartCoroutine(_AddFreezing(damageType, Piercing, Damage, FreezingTime));
    }
    private IEnumerator _AddFreezing(DamageType damageType, float Piercing, float Damage, float FreezingTime)
    {
        FreezingStack += 1;

        Freezing = true;
        AddDamage(damageType, Piercing, Damage);
        _MonsterNav.SetNavMesh(false);
        // 동결 효과
        ChangeColor(Color.white);

        yield return new WaitForSeconds(FreezingTime);

        FreezingStack -= 1;
        if (FreezingStack <= 0)
        {
            Freezing = false;
            _MonsterNav.SetNavMesh(true);
            // 동결 효과 제거
            ChangeColor(NomalColor);
        }
    }
    #endregion
    // -------------------- 받는 피해 증가 효과 --------------------
    #region IDT (Increased Damage Taken)




    #endregion
}