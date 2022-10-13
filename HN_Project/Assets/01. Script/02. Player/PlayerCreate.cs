using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCreate : MonoBehaviour
{
    public Material BuildMaterial;

    [Header("TowerPrefab")]
    public GameObject[] Tower = new GameObject[0];

    private bool IsCreate = false;
   
    private void Update()
    {
        if (PlayerInput.Key_Num1 && !PlayerInput.Key_MouseL) { TowerCreateButton(0); }
        if (PlayerInput.Key_Num2 && !PlayerInput.Key_MouseL) { TowerCreateButton(1); }
        if (PlayerInput.Key_Num3 && !PlayerInput.Key_MouseL) { TowerCreateButton(2); }
        if (PlayerInput.Key_Num4 && !PlayerInput.Key_MouseL) { TowerCreateButton(3); }
    }

    private GameObject GetTower(int TowerNum)
    {
        if (TowerNum >= Tower.Length)
        {
            return null;
        }
        return Instantiate(Tower[TowerNum]);
    }

    private void TowerCreateButton(int TowerNum)
    {
        if (!IsCreate)
            StartCoroutine(_TowerCreate(TowerNum));
    }

    private IEnumerator _TowerCreate(int TowerNum)
    {
        IsCreate = true;
        Renderer BuildColor = null;
        
        GameObject T = GetTower(TowerNum);

        if (T == null)
        { Debug.LogWarning("���� �� Ÿ���� ȣ���߽��ϴ�."); IsCreate = false; }
        else
        {
            //�� �ٲٱ�
            T.GetComponent<NavMeshObstacle>().enabled = false;
            BuildColor = T.GetComponent<Renderer>();
            BuildColor.material = BuildMaterial;
        }
        while (IsCreate)
        {
            GameObject M = CameraPoint.GetMousePoint("Map");

            if (M != null && M.tag == "Plane")
            {
                Vector3 BuildVector = M.transform.position; BuildVector.y += 1;
                Plane _Plane = M.GetComponent<Plane>();

                bool IsCheck = false;
                if (!_Plane.GetTowerBuild() || _Plane.GetTower())
                { ColorChange(BuildColor, Color.red, 0.4f); IsCheck = false; }
                else
                { ColorChange(BuildColor, Color.blue, 0.4f); IsCheck = true; }

                T.transform.position = BuildVector;

                if (PlayerInput.Key_MouseL && IsCheck)
                {
                    GameObject TOWER = GetTower(TowerNum);
                    Debug.Log($"Ÿ�� ���� : {TOWER.name}");
                    TOWER.transform.position = BuildVector;
                    _Plane.SetTower(true);
                    break;
                }
                else if (PlayerInput.Key_MouseL && !IsCheck)
                { Debug.LogWarning("Ÿ���� ���� �� ���� ��ġ�Դϴ�."); break; }
            }
            
            if (PlayerInput.Key_Escape) { break; }

            yield return null;
        }
        IsCreate = false;
        Destroy(T);
    }

    private void ColorChange(Renderer renderer, Color color ,float a)
    {
        Color Col = renderer.material.color;
        Col = color;
        Col.a = a;
        renderer.material.color = Col;
    }
}