using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // ����ƶ��ٶ�

    [SerializeField]
    private float lockSensitivity = 3f; // �����ת������

    [SerializeField]
    private PlayerController controller; // PlayerController���ã����ڴ�������

    // ��Ϸ��ʼʱ�������
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ÿ֡��������
    void Update()
    {
        // ��ȡ��������
        float xMove = Input.GetAxisRaw("Horizontal"); // ˮƽ�������루A/D����
        float yMove = Input.GetAxisRaw("Vertical"); // ��ֱ�������루W/S����

        // �����ƶ����򲢹�һ���������ٶ�
        Vector3 velocity = (transform.right * xMove + transform.forward * yMove).normalized * speed;

        // ���ƶ��ٶȴ��ݸ�PlayerController
        controller.Move(velocity);

        // ��ȡ�������
        float xMouse = Input.GetAxisRaw("Mouse X"); // ���ˮƽ�ƶ�
        float yMouse = Input.GetAxisRaw("Mouse Y"); // ��괹ֱ�ƶ�

        // ������ת��
        Vector3 yRotation = new Vector3(0f, xMouse, 0f) * lockSensitivity; // ˮƽ��ת����Y�ᣩ
        Vector3 xRotation = new Vector3(-yMouse, 0f, 0f) * lockSensitivity; // ��ֱ��ת����X�ᣩ

        // ����ת�����ݸ�PlayerController
        controller.Rotate(yRotation, xRotation);
    }
}