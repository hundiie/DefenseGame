using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterManager : MonoBehaviour
{
    [Header("MonsterPrefab")]
    public GameObject[] MonsterPrefab = new GameObject[0];
    
    [Header("Location")]
    public GameObject Start;
    public GameObject End;

    [Header("Stage")]
    public int Stage = 1;
    public float SpawnTime;


    [SerializeField] private List<int> StageMonster;
    private bool IsStage;

    private void Awake()
    {
        IsStage = false;
    }

    private void Update()
    {
        if (PlayerInput.Key_F)
        {
            StageStart(Stage);
        }
    }

    private void StageStart(int stage)
    {
        if (IsStage)
        {
            return;
        }
            switch (stage)
        {
            case 1:
                {
                    AddMonster(0, 10);
                    AddMonster(1, 5);
                    AddMonster(2, 5);
                    AddMonster(3, 5);
                    AddMonster(4, 5);
                    StartCoroutine(_StageStart());
                }
                break;
            case 2:
                {
                    AddMonster(0, 10);
                    AddMonster(1, 5);
                    AddMonster(2, 5);
                    AddMonster(3, 5);
                    AddMonster(4, 5);
                    StartCoroutine(_StageStart());
                }
                break;
            case 3:
                {
                    AddMonster(0, 10);
                    AddMonster(1, 5);
                    AddMonster(2, 5);
                    AddMonster(3, 5);
                    AddMonster(4, 5);
                    StartCoroutine(_StageStart());
                }
                break;
            case 4:
                {
                    AddMonster(0, 10);
                    AddMonster(1, 5);
                    AddMonster(2, 5);
                    AddMonster(3, 5);
                    AddMonster(4, 5);
                    StartCoroutine(_StageStart());
                }
                break;
            case 5:
                {
                    AddMonster(0, 10);
                    AddMonster(1, 5);
                    AddMonster(2, 5);
                    AddMonster(3, 5);
                    AddMonster(4, 5);
                    StartCoroutine(_StageStart());
                }
                break;
            default:
                Stage++;
                break;
        }


    }

    private void AddMonster(int MonsterNumber, int AddNamber)
    {
        for (int i = 0; i < AddNamber; i++)
        {
            StageMonster.Add(MonsterNumber);
        }
    }
    
    private IEnumerator _StageStart()
    {
        if (!IsStage)
        {
            IsStage = true;
            
            for (int i = 0; i < StageMonster.Count; i++)
            {
                GameObject Mon = Instantiate(MonsterPrefab[StageMonster[i]], Start.transform.position, Quaternion.identity);
                Mon.GetComponent<MonsterNav>().SetTarget(End.transform.position);

                yield return new WaitForSeconds(SpawnTime);
            }

            Stage += 1;
            StageMonster.Clear();
            IsStage = false;
        }
    }
}
