using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // 玩家移动速度

    [SerializeField]
    private float lockSensitivity = 3f; // 鼠标旋转灵敏度

    [SerializeField]
    private PlayerController controller; // PlayerController引用，用于传递输入

    // 游戏开始时锁定鼠标
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // 每帧处理输入
    void Update()
    {
        // 获取键盘输入
        float xMove = Input.GetAxisRaw("Horizontal"); // 水平方向输入（A/D键）
        float yMove = Input.GetAxisRaw("Vertical"); // 垂直方向输入（W/S键）

        // 计算移动方向并归一化，乘以速度
        Vector3 velocity = (transform.right * xMove + transform.forward * yMove).normalized * speed;

        // 将移动速度传递给PlayerController
        controller.Move(velocity);

        // 获取鼠标输入
        float xMouse = Input.GetAxisRaw("Mouse X"); // 鼠标水平移动
        float yMouse = Input.GetAxisRaw("Mouse Y"); // 鼠标垂直移动

        // 计算旋转量
        Vector3 yRotation = new Vector3(0f, xMouse, 0f) * lockSensitivity; // 水平旋转（绕Y轴）
        Vector3 xRotation = new Vector3(-yMouse, 0f, 0f) * lockSensitivity; // 垂直旋转（绕X轴）

        // 将旋转量传递给PlayerController
        controller.Rotate(yRotation, xRotation);
    }
}