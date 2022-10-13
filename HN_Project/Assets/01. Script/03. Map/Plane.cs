using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Plane : MonoBehaviour
{
    NavMeshObstacle _NavMeshObstacle;

    public bool MonsterMove;
    public bool TowerBuild;
    public bool Tower;

    private void Awake()
    {
        _NavMeshObstacle = GetComponent<NavMeshObstacle>();
    }
    private void Start()
    {
        bool move = MonsterMove ? _NavMeshObstacle.enabled = false : _NavMeshObstacle.enabled = true;
    }

    public void SetMonsterMove(bool monsterMove) { MonsterMove = monsterMove; }
    public void SetTowerBuild(bool towerBuild) { TowerBuild = towerBuild; }
    public void SetTower(bool tower) { Tower = tower; }

    public bool GetMonsterMove() { return MonsterMove; }
    public bool GetTowerBuild() { return TowerBuild; }
    public bool GetTower() { return Tower; }
}
