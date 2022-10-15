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
        TowerStatusText.text += "���� Ÿ�� :" + _TowerStatus.GetDamageType() + "\n";
        
        TowerStatusText.text += "���ݷ�    :" + _TowerStatus.GetAttack_Power() + "\n";
        TowerStatusText.text += "���ݼӵ�   :" + _TowerStatus.GetAttack_Speed() + "\n";
        TowerStatusText.text += "�����    :" + _TowerStatus.GetAttack_Pierce() + "\n";
        TowerStatusText.text += "��Ÿ�    :" + _TowerStatus.GetAttack_Range() + "\n";

        TowerStatusText.text += "��Ƽ��    :" + _TowerStatus.GetTaget_Multi() + "\n";
        TowerStatusText.text += "�����    :" + _TowerStatus.GetTaget_chain() + "\n";
        TowerStatusText.text += "���� ����  :" + _TowerStatus.GetExplosion_Range() + "\n";


        switch (_TowerStatus.GetTowerType())
        {
            case TOWER.Nomal:return;
            case TOWER.Poison:
                {
                    TowerStatusText.text += "�� ���ӽð� :" + _TowerStatus.GetPoison_Time() + "\n";
                    return;
                }
            case TOWER.Fire:
                {
                    TowerStatusText.text += "ƽ Ƚ��   :" + _TowerStatus.GetFire_TickCount() + "\n";
                    TowerStatusText.text += "ƽ �ӵ�   :" + _TowerStatus.GetFire_TickSpeed() + "\n";
                    return;
                }
            case TOWER.Slow:
                {
                    TowerStatusText.text += "���� ����  :" + _TowerStatus.GetSlow_Value() + "%\n";
                    TowerStatusText.text += "���� �ð�  :" + _TowerStatus.GetSlow_Time() + "%\n";
                    TowerStatusText.text += "���� Ȯ��  :" + _TowerStatus.GetSlow_Freezing_Value() + "%\n";
                    TowerStatusText.text += "���� �ð�  :" + _TowerStatus.GetSlow_Freezing_Time() + "%\n";
                    return;
                }
        }
    }
}
