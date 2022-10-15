using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCreate : MonoBehaviour
{
    public Material BuildMaterial;
    private GameObject[] Tower;

    private bool IsCreate = false;

    private GameObject PickTower;

    private void Awake()
    {
        Tower = new GameObject[TowerManager.GetTowerPrefabCount()];
        for (int i = 0; i < Tower.Length; i++)
        {
            Tower[i] = TowerManager.GetTowerPrefab(i);
        }
    }

    private void Update()
    {
        if (!IsCreate && PlayerInput.Key_MouseL) { PickTower = GetPlaneTower(); }

        if (PlayerInput.Key_Num1 && !PlayerInput.Key_MouseL) { Button_TowerCreate(0); }
        if (PlayerInput.Key_Num2 && !PlayerInput.Key_MouseL) { Button_TowerCreate(1); }
        if (PlayerInput.Key_Num3 && !PlayerInput.Key_MouseL) { Button_TowerCreate(2); }
        if (PlayerInput.Key_Num4 && !PlayerInput.Key_MouseL) { Button_TowerCreate(3); }
        if (PlayerInput.Key_Num5 && !PlayerInput.Key_MouseL) { Button_TowerSell(); }
    }
    private void ColorChange(Renderer renderer, Color color ,float a)
    {
        Color Col = renderer.material.color;
        Col = color;
        Col.a = a;
        renderer.material.color = Col;
    }

    #region Ÿ�� ����

    private GameObject GetTower(GameObject Plane, int TowerNum)
    {
        if (TowerNum >= Tower.Length){ return null; }

        GameObject InstantiateTower = Instantiate(Tower[TowerNum], new Vector3(0, -100, 0), Quaternion.identity);
        if (Plane != null) { InstantiateTower.transform.parent = Plane.transform; }
        
        return InstantiateTower;
    }
    private IEnumerator _TowerCreate(int TowerNum)
    {
        IsCreate = true;
        Renderer[] BuildColor = null;
        
        GameObject T = GetTower(null, TowerNum);

        if (T == null)
        { Debug.LogWarning("���� �� Ÿ���� ȣ���߽��ϴ�."); IsCreate = false; }
        else
        {
            //�� �ٲٱ�
            T.GetComponent<NavMeshObstacle>().enabled = false;
            BuildColor = T.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < BuildColor.Length; i++)
            {
                BuildColor[i].material = BuildMaterial;
            }
        }
        while (IsCreate)
        {
            GameObject MAP = CameraPoint.GetMousePoint("Map");

            if (MAP != null && MAP.tag == "Plane")
            {
                Vector3 BuildVector = MAP.transform.position; BuildVector.y += 1;
                Plane _Plane = MAP.GetComponent<Plane>();

                bool IsCheck = false;

                // �� �ٲ�
                if (!_Plane.GetTowerBuild() || _Plane.GetTower())
                {
                    for (int i = 0; i < BuildColor.Length; i++)
                    {
                        ColorChange(BuildColor[i], Color.red, 0.3f);
                    }
                    IsCheck = false; 
                }
                else
                {
                    for (int i = 0; i < BuildColor.Length; i++)
                    {
                        ColorChange(BuildColor[i], Color.blue, 0.3f);
                    }
                    IsCheck = true; 
                }

                T.transform.position = BuildVector;

                if (PlayerInput.Key_MouseL && IsCheck)
                {
                    GameObject TOWER = GetTower(MAP, TowerNum);
                    Debug.Log($"Ÿ�� ���� : {TOWER.name}");
                    
                    TOWER.transform.position = BuildVector;
                    _Plane.SetPlaneTower(TOWER);
                    _Plane.SetTower(true);
                    MAP.layer = 9;
                    
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

    #endregion

    #region Ÿ�� �Ǹ�
    private GameObject SavePlane = null;
    private GameObject GetPlaneTower()
    {
        // Ÿ�� �ҷ���
        GameObject MAP = CameraPoint.GetMousePoint("Tower");
        if (MAP == null) // Ÿ���� ������ Ÿ�� �ٴ��� �ҷ���
        { MAP = CameraPoint.GetMousePoint("TowerPlane"); }
        else // Ÿ���� �ִٸ� Ÿ���� �θ� �ҷ� �ٴ��� �ҷ���
        { MAP = MAP.transform.parent.gameObject; }

        // ����� ��ġ�� �ٸ��� �� ����
        if (SavePlane != null) { SavePlane.GetComponent<Plane>().SetNomalColor(); SavePlane = null; }
        
        if (MAP != null)
        {
            MAP.GetComponent<Plane>().SetColor(Color.cyan);

            SavePlane = MAP;

            return MAP;
        }
        return null;
    }
    private void _TowerSell(GameObject plane)
    {
        if (plane == null) { return; }
        Debug.Log("Ÿ�� �Ǹ�");
        Plane _plane = plane.GetComponent<Plane>();
        //Ÿ�� ����
        Destroy(_plane.transform.GetChild(0).gameObject);

        // ���� �� ó��
        if (SavePlane != null) { SavePlane.GetComponent<Plane>().SetNomalColor(); SavePlane = null; }
        
        _plane.SetPlaneTower(null);
        _plane.SetTower(false);
        
        PickTower = null;
    }

    #endregion

    public void Button_TowerCreate(int TowerNum)
    {
        if (!IsCreate)
            StartCoroutine(_TowerCreate(TowerNum));
    }
    public void Button_TowerSell()
    {
        _TowerSell(PickTower);
    }
}