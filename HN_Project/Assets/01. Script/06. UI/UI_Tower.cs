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
        TowerStatusText.text = _TowerStatus.GetTowerName() + "\n";
        TowerStatusText.text += "공격 타입 :" + _TowerStatus.GetDamageType() + "\n";
        
        TowerStatusText.text += "공격력    :" + _TowerStatus.GetAttack_Power() + "\n";
        TowerStatusText.text += "공격속도   :" + _TowerStatus.GetAttack_Speed() + "\n";
        TowerStatusText.text += "관통력    :" + _TowerStatus.GetAttack_Pierce() + "\n";
        TowerStatusText.text += "사거리    :" + _TowerStatus.GetAttack_Range() + "\n";

        TowerStatusText.text += "멀티샷    :" + _TowerStatus.GetTaget_Multi() + "\n";
        TowerStatusText.text += "연쇄수    :" + _TowerStatus.GetTaget_chain() + "\n";
        TowerStatusText.text += "폭발 범위  :" + _TowerStatus.GetExplosion_Range() + "\n";


        switch (_TowerStatus.GetTowerType())
        {
            case TOWER.Nomal:return;
            case TOWER.Poison:
                {
                    TowerStatusText.text += "독 지속시간 :" + _TowerStatus.GetPoison_Time() + "\n";
                    return;
                }
            case TOWER.Fire:
                {
                    TowerStatusText.text += "틱 횟수   :" + _TowerStatus.GetFire_TickCount() + "\n";
                    TowerStatusText.text += "틱 속도   :" + _TowerStatus.GetFire_TickSpeed() + "\n";
                    return;
                }
            case TOWER.Slow:
                {
                    TowerStatusText.text += "빙결 수준  :" + _TowerStatus.GetSlow_Value() + "%\n";
                    TowerStatusText.text += "빙결 시간  :" + _TowerStatus.GetSlow_Time() + "%\n";
                    TowerStatusText.text += "동결 확률  :" + _TowerStatus.GetSlow_Freezing_Value() + "%\n";
                    TowerStatusText.text += "동결 시간  :" + _TowerStatus.GetSlow_Freezing_Time() + "%\n";
                    return;
                }
        }
    }
}
