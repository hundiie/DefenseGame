using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterNav : MonoBehaviour
{
    private NavMeshAgent _NavMeshAgent;
    private MonsterStatus _MonsterState;
    
    private void Awake()
    {
        _NavMeshAgent = GetComponent<NavMeshAgent>();
        _MonsterState = GetComponent<MonsterStatus>();
    }
    private void Start()
    {
        SetMoveSpeed(_MonsterState.GetMoveSpeed());
    }

    public void SetMoveSpeed(float MoveSpeed)
    {
        _NavMeshAgent.speed = MoveSpeed;
    }
    public void SetTarget(Vector3 TargetPosition)
    {
        _NavMeshAgent.destination = TargetPosition;
    }

}
