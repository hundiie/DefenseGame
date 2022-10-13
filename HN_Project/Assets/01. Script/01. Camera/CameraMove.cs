using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Camera")]
    public float CameraSpeed;

    [Header("Limit X")]
    public float Limit_Right;
    public float Limit_Left;

    [Header("Limit Z")]
    public float Limit_Up;
    public float Limit_Down;

    private void FixedUpdate()
    {
        Move(PlayerInput.Horizontal, PlayerInput.Vertical);
    }
    private void Move(float Horizontal, float Vertical)
    {
        if (Limit_Right > transform.position.x && Horizontal > 0)
        {
            transform.position += new Vector3(Horizontal, 0, 0) * CameraSpeed * Time.deltaTime;
        }
        else if (transform.position.x > -Limit_Left && Horizontal < 0)
        {
            transform.position += new Vector3(Horizontal, 0, 0) * CameraSpeed * Time.deltaTime;
        }

        if (Limit_Up > transform.position.z && Vertical > 0)
        {
            transform.position += new Vector3(0, 0, Vertical) * CameraSpeed * Time.deltaTime;
        }
        else if(transform.position.z > -Limit_Down && Vertical < 0)
        {
            transform.position += new Vector3(0, 0, Vertical) * CameraSpeed * Time.deltaTime;
        }
    }
}
