using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb; // ��ҵĸ�����������������˶�
    [SerializeField]
    private Camera cam; // ��ҵ�������������ӽǿ���

    private Vector3 velocity = Vector3.zero; // �洢�ƶ��ٶ�
    private Vector3 yRotation = Vector3.zero; // �洢ˮƽ��ת������Y�ᣩ
    private Vector3 xRotation = Vector3.zero; // �洢��ֱ��ת������X�ᣩ

    // �����ƶ��ٶ�
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // ������ת��
    public void Rotate(Vector3 _yRotation, Vector3 _xRotation)
    {
        yRotation = _yRotation;
        xRotation = _xRotation;
    }

    // ִ���ƶ�
    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); // �����ٶ��ƶ�����λ��
        }
    }

    // ִ����ת
    private void PerformRotation()
    {
        if (yRotation != Vector3.zero)
        {
            rb.transform.Rotate(yRotation); // ��Y����ת��ң�ˮƽ��ת��
        }
        if (xRotation != Vector3.zero)
        {
            cam.transform.Rotate(xRotation); // ��X����ת���������ֱ��ת��
        }
    }

    // FixedUpdate�д���������ص��ƶ�����ת
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}