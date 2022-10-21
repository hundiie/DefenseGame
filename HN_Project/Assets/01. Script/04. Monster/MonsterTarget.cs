using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTarget : MonoBehaviour
{
    [SerializeField] private List<GameObject> TowerTarget;

    private void Awake()
    {
        TowerTarget = new List<GameObject>();
    }
    public void AddTowerTarget(GameObject tower)
    {
        TowerTarget.Add(tower);
    }
    public void RemoteTowerTarget(GameObject tower)
    {
        TowerTarget.Remove(tower);
    }
    public void ClearTowerTarget()
    {
        for (int i = 0; i < TowerTarget.Count; i++)
        {
            if (TowerTarget[i] != null)
            { TowerTarget[i].GetComponent<TowerAttack>().RemoteMonster(gameObject); }
            else { TowerTarget.Remove(TowerTarget[i]); }
        }
        TowerTarget.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            other.GetComponent<TowerAttack>().AddMonster(gameObject);
            AddTowerTarget(other.gameObject);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            other.GetComponent<BulletManager>().GetNextTarget(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Tower"))
        {
            other.GetComponent<TowerAttack>().RemoteMonster(gameObject);
            RemoteTowerTarget(other.gameObject);
        }
    }
}
