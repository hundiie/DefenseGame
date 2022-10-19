using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Tower : MonoBehaviour
{
    public Text TowerStatusText;
    public void SetText(GameObject Tower)
    {
        TowerStatus _TowerStatus = Tower.GetComponent<TowerStatus>();
    }
}
