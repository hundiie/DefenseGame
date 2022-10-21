using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private SphereCollider _SphereCollider;
    private TowerInGame _TowerInGame;

    private GameObject BulletSpawnPoint;
    private GameObject BulletPrefab;

    [SerializeField] private List<GameObject> TargetMonster;

    private void Awake()
    {
        _SphereCollider = GetComponent<SphereCollider>();
        _TowerInGame = GetComponent<TowerInGame>();
        BulletSpawnPoint = transform.GetChild(0).gameObject;
        BulletPrefab = Resources.Load<GameObject>("01. Prefab/02. Tower/Bullet");
    }
    private void Start()
    {
        _SphereCollider.radius = _TowerInGame.Range;
    }

    float AttackDelta = Mathf.Infinity;
    private void Update()
    {
        AttackDelta += Time.deltaTime;
        if (TargetMonster.Count != 0)
        {
            //공격 속도
            if (AttackDelta > 1 / _TowerInGame.Speed)
            {
                AttackDelta = 0;

                //멀티샷
                for (int i = 0; i < _TowerInGame.Multi; i++)
                {
                    // 타겟 수만큼 검사
                    if (i >= TargetMonster.Count) { break; }

                    // 타켓이 존재하면 발사
                    if (TargetMonster[i] != null)
                    {
                        transform.LookAt(TargetMonster[0].transform.position);
                        AttackTarget(TargetMonster[i]);
                    }
                    else { TargetMonster.Remove(TargetMonster[i]); }
                }
            }
        }
        
    }
    public void AttackTarget(GameObject TargetPosition)
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawnPoint.transform.position,Quaternion.identity);
        //bullet.transform.parent = gameObject.transform;
        
        BulletManager bulletManager = bullet.GetComponent<BulletManager>();
        bulletManager.SetTarget(TargetPosition);
        bulletManager.SetBullet(_TowerInGame);
    }

    public void AddMonster(GameObject Monster)
    {
        TargetMonster.Add(Monster);
    }

    public void RemoteMonster(GameObject Monster)
    {
        TargetMonster.Remove(Monster);
    }

}