using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Acceleration;
    [SerializeField] float MaxSpeed;
    [SerializeField] float RotationSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Camera;

    float CurSpeed;


    private void Start()
    {
        CurSpeed = MaxSpeed;
    }

    void Update()
    {
        ChiftControl();

        Move();  //����� ������,������� ��������� ��������� �������

        Rotate();  //����� ������,������� ��������� ��������� �������
    }

    private void ChiftControl()
    {
        // GetKey - ������� �������
        // GetKeyDown - ������� �� �������
        // GetKeyUp - ������� �������
        // || - ��� (��� bool)
        // T == T - T
        // F == T - F
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            CurSpeed = MaxSpeed * 2.5f;
        }
        else
        {
            CurSpeed = MaxSpeed;
        }
        // ���� shift �����, �� CurSpeed = MaxSpeed * 1.5
        // ���� �� �����, �� CurSpeed = MaxSpeed
    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal"); // ��������� ������ ����� �� ������������ �� �������������� ��� A � D
        float ver = Input.GetAxis("Vertical"); //  ��������� ������ ����� �� ������������ �� �������������� ��� W � S

        rb.AddForce(Camera.forward * Acceleration * Time.deltaTime * ver);
        rb.AddForce(Camera.right * Acceleration * Time.deltaTime * hor);

        SpeedControl();


        /*Vector3 velocity = rb.velocity;
        // -MaxSpeed < x < MaxSpeed
        velocity.x = Mathf.Clamp(velocity.x, -MaxSpeed, MaxSpeed);
        velocity.z = Mathf.Clamp(velocity.z, -MaxSpeed, MaxSpeed);
        rb.velocity = velocity;*/


        // rb.velocity.x = Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed);
        // rb.velocity.z = Mathf.Clamp(rb.velocity.z, -MaxSpeed, MaxSpeed);
    }

    // �������� ��������, ���������, ��� ����� �� �������� ������� ������
    private void SpeedControl()
    {
        // (1, 0.5, 2)
        // (2, 1, 4)

        // ���������� �� flatVel ����� ������ ��������� �� x � z velocity ������, �� Y=0
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // ���� ��������� (�����) ������� ������ ������������ ��������, ��...
        if (flatVel.magnitude > CurSpeed)
        {
            // (2; 5; 3) / 38 = (0.0526, 0.13157, 0,0789) = (0.263, 0.65785, 0.3945)
            // ������� ������� ������� � �������� �� �� ������������ ��������. �������� ���������� �������� ������
            Vector3 limitedVel = flatVel.normalized * CurSpeed;
            // �������� ������������ �������� ������, �������� ��� ���� �� ����������� � �������� �� ��� Y
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

    private void Rotate()
    {
        float yRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, yRotation * RotationSpeed * Time.deltaTime, 0);
    }
}


// ���������� - �������, �������� ���� �������� ������������� ����. ���������� ������ ����������� ������ ������ (local) (��������� ����������)
// ���� - �������, �������� ���� �������� ������������� ����. ���������� ������ ����������� ��� ������ (global) (���������� ����������)