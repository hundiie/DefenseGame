using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    private MonsterStatus _MonsterStatus;

    private GameObject Canvas;
    private Slider HpSlider;

    private float MaxHP;
    [SerializeField] private float HP;

    public bool Die;
    private void Awake()
    {
        _MonsterStatus = GetComponent<MonsterStatus>();
        Canvas = transform.GetChild(0).gameObject;
        HpSlider = Canvas.transform.GetChild(0).GetComponent<Slider>();
    }

    private void Start()
    {
        MaxHP = _MonsterStatus.GetMaxHP();
        HP = _MonsterStatus.GetHP();
        Die = false;
    }

    #region MaxHP
    public void SetMaxHP(float Num) { MaxHP = Num; }
    public void AddMaxHP(float Num) { MaxHP += Num; }
    #endregion
    #region HP
    public void SetHP(float Num) { HP = Num; }
    public void AddHP(float Num) { HP += Num; }
    public float GetHP() { return HP; }

    #endregion
    #region Die
    public bool GetDie()
    {
        return Die;
    }

    #endregion

    public void HideHP(bool Is)
    {
        if (!Is)
        {
            Canvas.SetActive(false);
        }
        else
        {
            Canvas.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        HpSlider.value = HP / (MaxHP / 100);
        Canvas.transform.rotation = Quaternion.Euler(90, -transform.rotation.y, 0);
        if (HP <= 0)
        {
            HideHP(false);
            Die = true;
        }
    }


}
