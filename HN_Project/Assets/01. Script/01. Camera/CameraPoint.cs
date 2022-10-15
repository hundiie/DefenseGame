using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    private static GameObject MousePoint(string LayerName)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit;

        hit = Physics.RaycastAll(ray, 200f);
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.gameObject.layer == LayerMask.NameToLayer(LayerName))
            {
                return hit[i].collider.gameObject;
            }
        }

        return null;
    }

    public static GameObject GetMousePoint(string TagName)
    {
        return MousePoint(TagName);
    }
}
