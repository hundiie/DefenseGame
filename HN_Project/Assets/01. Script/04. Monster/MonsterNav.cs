using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterNav : MonoBehaviour
{
    private NavMeshAgent _NavMeshAgent;
    private MonsterStatus _MonsterState;
    private Vector3 SavePosition;
    private void Awake()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        _MonsterState = GetComponent<MonsterStatus>();
    }
    private void Start()
    {
        SetMoveSpeed(_MonsterState.GetMoveSpeed());
    }
    public float GetMoveSpeed()
    {
        return _NavMeshAgent.speed;
    }
    public void SetMoveSpeed(float MoveSpeed)
    {
        _NavMeshAgent.speed = MoveSpeed;
    }
    public void SetTarget(Vector3 TargetPosition)
    {
        SavePosition = TargetPosition;
        _NavMeshAgent.destination = TargetPosition;
    }

    public void SetNavMesh(bool Value)
    {
        _NavMeshAgent.enabled = Value;
        if (Value) { SetTarget(SavePosition); }
    }
}
