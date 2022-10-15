using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float Horizontal { get; private set; }
    public static float Vertical { get; private set; }

    public static bool Key_MouseL { get; private set; }
    public static bool Key_MouseL_Up { get; private set; }
    public static bool Key_MouseL_Down { get; private set; }
    public static bool Key_MouseR { get; private set; }
    public static bool Key_MouseR_Up { get; private set; }
    public static bool Key_MouseR_Down { get; private set; }

    public static bool Key_Num0 { get; private set; }
    public static bool Key_Num1 { get; private set; }
    public static bool Key_Num2 { get; private set; }
    public static bool Key_Num3 { get; private set; }
    public static bool Key_Num4 { get; private set; }
    public static bool Key_Num5 { get; private set; }
    public static bool Key_Num6 { get; private set; }
    public static bool Key_Num7 { get; private set; }
    public static bool Key_Num8 { get; private set; }
    public static bool Key_Num9 { get; private set; }

    public static bool Key_Escape { get; private set; }
    public static bool Key_Space { get; private set; }

    public static bool Key_Q { get; private set; }
    public static bool Key_E { get; private set; }
    public static bool Key_R { get; private set; }
    public static bool Key_F { get; private set; }


    private void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        Key_MouseL = Input.GetMouseButton(0);
        Key_MouseL_Up = Input.GetMouseButtonUp(0);
        Key_MouseL_Down = Input.GetMouseButtonDown(0);
        Key_MouseR = Input.GetMouseButton(1);
        Key_MouseR_Up = Input.GetMouseButtonUp(1);
        Key_MouseR_Down = Input.GetMouseButtonDown(1);


        Key_Num0 = Input.GetKey(KeyCode.Alpha0);
        Key_Num1 = Input.GetKey(KeyCode.Alpha1);
        Key_Num2 = Input.GetKey(KeyCode.Alpha2);
        Key_Num3 = Input.GetKey(KeyCode.Alpha3);
        Key_Num4 = Input.GetKey(KeyCode.Alpha4);
        Key_Num5 = Input.GetKey(KeyCode.Alpha5);
        Key_Num6 = Input.GetKey(KeyCode.Alpha6);
        Key_Num7 = Input.GetKey(KeyCode.Alpha7);
        Key_Num8 = Input.GetKey(KeyCode.Alpha8);
        Key_Num9 = Input.GetKey(KeyCode.Alpha9);

        Key_Escape = Input.GetKey(KeyCode.Escape);
        Key_Space = Input.GetKey(KeyCode.Space);

        Key_Q = Input.GetKey(KeyCode.Q);
        Key_E = Input.GetKey(KeyCode.E);
        Key_R = Input.GetKey(KeyCode.R);
        Key_F = Input.GetKey(KeyCode.F);

    }
}
