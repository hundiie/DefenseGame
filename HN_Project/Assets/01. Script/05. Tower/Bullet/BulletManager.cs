using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private SphereCollider _SphereCollider;

    private GameObject TargetObject;

    private int AttackType;
    private int DamageType;

    private float Power;
    private float Range;
    private float Pierce;
    private float EX_Range;

    [SerializeField] private int Chain;

    private float PoisonTime;

    private float FireCount;
    private float FireTime;

    private float SlowValue;
    private float SlowTime;

    private float FreezingValue;
    private float FreezingTime;

    private void Start()
    {
        _SphereCollider = GetComponent<SphereCollider>();
        _SphereCollider.radius = 0.1f;
        _SphereCollider.enabled = false;
        StartCoroutine(MoveTaget(TargetObject.transform.position));
    }
    public void SetTarget(GameObject targetPosition)
    {
        TargetObject = targetPosition;
    }
    public void SetBullet(TowerInGame towerInGame)
    {
        AttackType = towerInGame.AttackType;
        DamageType = towerInGame.DamageType;

        Power = towerInGame.Power;
        Range = towerInGame.Range;
        Pierce = towerInGame.Pierce;
        EX_Range = towerInGame.EX_Range;
        Chain = towerInGame.Chain;

        PoisonTime = towerInGame.PoisonTime;
        
        FireCount = towerInGame.FireCount;
        FireTime = towerInGame.FireTime;

        SlowValue = towerInGame.IceValue;
        SlowTime = towerInGame.IceTime;

        FreezingValue = towerInGame.FreezingValue;
        FreezingTime = towerInGame.FreezingTime;
    }

    private IEnumerator MoveTaget(Vector3 TargetPos)
    {
        while (true)
        {
            float distence = Vector3.Distance(transform.position, TargetPos);
            transform.position = Vector3.MoveTowards(transform.position, TargetPos, 0.1f);
            if (distence < 0.03f) { break; }
            yield return null;
        }

        // 공격 부분


        Chain --;
        if (Chain <= 0)
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
        StartCoroutine(_SetNewTarget());
    }

    public GameObject NextTarget = null;
    private IEnumerator _SetNewTarget()
    {
        _SphereCollider.enabled = true;
        while (true)
        {
            _SphereCollider.radius += Time.deltaTime * 200;
            if (_SphereCollider.radius >= Range * 7)
            {
                NextTarget = null; 
                StopAllCoroutines();
                Destroy(gameObject);
                break;
            }
            
            if (NextTarget != null)
            {
                _SphereCollider.radius = 0.1f;
                _SphereCollider.enabled = false;
                break;
            }
            yield return null;
        }
        Debug.Log(NextTarget);
        if (NextTarget != null)
        {
            StartCoroutine(MoveTaget(NextTarget.transform.position));
        }
        NextTarget = null;
    }

    public void GetNextTarget(GameObject nextTarget)
    {
        if (nextTarget != TargetObject && NextTarget == null)
        {
            NextTarget = nextTarget;
            TargetObject = NextTarget;
        }
    }
}
