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
        if (PlayerInput.Key_T && !PlayerInput.Key_MouseL) { Button_TowerSell(); }
        if (PlayerInput.Key_Num1 && !PlayerInput.Key_MouseL) { Button_TowerCreate(0); }
        if (PlayerInput.Key_Num2 && !PlayerInput.Key_MouseL) { Button_TowerCreate(1); }
        if (PlayerInput.Key_Num3 && !PlayerInput.Key_MouseL) { Button_TowerCreate(2); }
        if (PlayerInput.Key_Num4 && !PlayerInput.Key_MouseL) { Button_TowerCreate(3); }
    }
    private void LateUpdate()
    {
        if (!IsCreate && PlayerInput.Key_MouseL)
        {
            GameObject p = GetTowerPlane();
            if (p != null) { PickTower = p; }
        }
    }
    private void ColorChange(Renderer renderer, Color color ,float a)
    {
        Color Col = renderer.material.color;
        Col = color;
        Col.a = a;
        renderer.material.color = Col;
    }

    #region 타워 제작

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
        { Debug.LogWarning("범위 외 타워를 호출했습니다."); IsCreate = false; }
        else
        {
            //색 바꾸기
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

                // 색 바꿈
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
                    Debug.Log($"타워 생성 : {TOWER.name}");
                    
                    TOWER.transform.position = BuildVector;
                    _Plane.SetPlaneTower(TOWER);
                    _Plane.SetTower(true);                    break;
                }
                else if (PlayerInput.Key_MouseL && !IsCheck)
                { Debug.LogWarning("타워를 지을 수 없는 위치입니다."); break; }
            }
            
            if (PlayerInput.Key_Escape) { break; }

            yield return null;
        }
        IsCreate = false;
        Destroy(T);
    }

    #endregion

    #region 타워 판매 & 업글

    private GameObject SavePlane = null;
    
    private GameObject GetTowerPlane()
    {
        GameObject MapTower = CameraPoint.GetMousePoint("Map");
        if (MapTower != null && MapTower.tag == "Plane" && MapTower.GetComponent<Plane>().GetTower())
        {
            if (SavePlane != null)
            {
                SavePlane.GetComponent<Plane>().SetNomalColor();
                SavePlane = null;
            }
            MapTower.GetComponent<Plane>().SetColor(Color.green);
            SavePlane = MapTower;
            return MapTower;
        }
        return null;
    }

    private void _TowerSell(GameObject plane)
    {
        if (plane == null) { return; }
        Debug.Log("타워 판매");
        Plane _plane = plane.GetComponent<Plane>();
        //타워 지움
        Destroy(_plane.transform.GetChild(0).gameObject);

        // 지운 후 처리
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
        GameObject Pick = PickTower;
        _TowerSell(Pick);
    }
}