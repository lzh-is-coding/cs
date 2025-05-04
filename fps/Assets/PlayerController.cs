using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb; // 玩家的刚体组件，用于物理运动
    [SerializeField]
    private Camera cam; // 玩家的摄像机，用于视角控制

    private Vector3 velocity = Vector3.zero; // 存储移动速度
    private Vector3 yRotation = Vector3.zero; // 存储水平旋转量（绕Y轴）
    private Vector3 xRotation = Vector3.zero; // 存储垂直旋转量（绕X轴）

    // 设置移动速度
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // 设置旋转量
    public void Rotate(Vector3 _yRotation, Vector3 _xRotation)
    {
        yRotation = _yRotation;
        xRotation = _xRotation;
    }

    // 执行移动
    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // 根据速度移动刚体位置
        }
    }

    // 执行旋转
    private void PerformRotation()
    {
        if (yRotation != Vector3.zero)
        {
            rb.transform.Rotate(yRotation); // 绕Y轴旋转玩家（水平旋转）
        }
        if (xRotation != Vector3.zero)
        {
            cam.transform.Rotate(xRotation); // 绕X轴旋转摄像机（垂直旋转）
        }
    }

    // FixedUpdate中处理物理相关的移动和旋转
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}