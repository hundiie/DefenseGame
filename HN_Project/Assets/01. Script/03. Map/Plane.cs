using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Plane : MonoBehaviour
{
    private NavMeshObstacle _NavMeshObstacle;
    private Renderer _Renderer;
    private Color NomalMaterial;
    
    public GameObject PlaneTower = null;

    public bool MonsterMove;
    public bool TowerBuild;
    public bool Tower;

    private void Awake()
    {
        _NavMeshObstacle = GetComponent<NavMeshObstacle>();
        _Renderer = GetComponent<Renderer>();
        NomalMaterial = _Renderer.material.color;
    }
    private void Start()
    {
        bool move = MonsterMove ? _NavMeshObstacle.enabled = false : _NavMeshObstacle.enabled = true;
    }
    public void SetNomalColor()
    {
        _Renderer.material.color = NomalMaterial;
    }
    public void SetColor(Color color)
    {
        _Renderer.material.color = color;
    }

    public void SetPlaneTower(GameObject _PlaneTower) { PlaneTower = _PlaneTower; }
    public void SetMonsterMove(bool monsterMove) { MonsterMove = monsterMove; }
    public void SetTowerBuild(bool towerBuild) { TowerBuild = towerBuild; }
    public void SetTower(bool tower) { Tower = tower; }

    public GameObject GetPlaneTower() { return PlaneTower; }
    public bool GetMonsterMove() { return MonsterMove; }
    public bool GetTowerBuild() { return TowerBuild; }
    public bool GetTower() { return Tower; }
}
