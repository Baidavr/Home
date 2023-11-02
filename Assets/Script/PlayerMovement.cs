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
    [SerializeField] float SpeedJump;
    [SerializeField] float RotationSpeed;
    [SerializeField] float RotationSpeedY;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Camera;
    [SerializeField] Jump _jump;

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

        Jump();
    }

    private void Jump()
    {
        // ����
        // ������ ������� �������,
        // �� ����������� ������ �� Y = 5

        // ����(����.���������������(������������.������)) { ... }
        // � ������.��������� == ��
        if (Input.GetKeyDown(KeyCode.Space) && _jump.IsGrounded == true)
        {
            Vector3 jump = rb.velocity;
            jump.y = SpeedJump;
            rb.velocity = jump;
        }
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

        // forward - ����� -         -forward - backward - �����
        // right - ������� -         -right - left - ������
        rb.AddForce(transform.forward * Acceleration * Time.deltaTime * ver);
        rb.AddForce(transform.right * Acceleration * Time.deltaTime * hor);

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
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * RotationSpeed * Time.deltaTime, 0);

        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 Rotation = Camera.localRotation.eulerAngles;
        // rot.x = rot.x - mouseY
        // Clamp - �������� ����� ����� ����� ���������, ��������� �����, ����������� � ������������ ��������
        // clamp(5, 2, 6) = 5
        // clamp(1, 3, 7) = 3
        // clamp(-1, -3, -7) = -3
        // clamp(10, 3, 5) = 5
        //Rotation.x = Mathf.Clamp(Rotation.x - mouseY * RotationSpeed * Time.deltaTime, , );
        Rotation.x = Rotation.x - mouseY * RotationSpeedY * Time.deltaTime;
        if (Rotation.x > 180)
        {
            Rotation.x = Mathf.Clamp(Rotation.x, 360 - 70, 361);
        }
        else if (Rotation.x < 180)
        {
            Rotation.x = Mathf.Clamp(Rotation.x, -1, 45);
        }
        Camera.localRotation = Quaternion.Euler(Rotation);
    }
}


// ���������� - �������, �������� ���� �������� ������������� ����. ���������� ������ ����������� ������ ������ (local) (��������� ����������)
// ���� - �������, �������� ���� �������� ������������� ����. ���������� ������ ����������� ��� ������ (global) (���������� ����������)