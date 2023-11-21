using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // IsGrounded - �������� �� ������

    public bool IsGrounded;

    // �������� - ����������, ������� ��������� ����� '(' � ')'. ��� ������ ������������ �������� �� ����� ������
    // other = ...
    void OnTriggerStay(Collider other)
    {
        // ���� 
        // ���� (layer) other - ��� "Ground",
        // ��...

        IsGrounded = other.gameObject.layer == 3;
        //if (other.gameObject.layer == 3)
        //    IsGrounded = true;
        //else IsGrounded = false;
    }

    void OnTriggerExit(Collider other)
    {
        IsGrounded = false;
    }
}

/*
Start - ���������� ��� ������ ����� (����)
Update - ������������ ��� ������������� ��������. ���������� ������ ����
FixedUpdate - ������ ������������ ��� �����, ��������� � �������. ���������� 50 ��� � �������

���� ��������� � ���������� �������� IsTrigger (�� ��������� ������� �� ������ ����������):
OnTriggerEnter - ����������, ����� ������, �� ������� ����� ������, ������������ � �����-���� ������ �����������
OnTriggerStay - ����������, ����� ������, �� ������� ����� ������, ��������� � ������ �����������
OnTriggerExit - ����������, ����� ������, �� ������� ����� ������, ������� (��������� �������������) � ������ �����������

���� ��������� � ����������� �������� IsTrigger (��������� ������� �� ������ ����������):
OnCollisionEnter - ����������, ����� ������, �� ������� ����� ������, ������������ � �����-���� ������ �����������
OnCollisionStay - ����������, ����� ������, �� ������� ����� ������, ��������� � ������ �����������
OnCollisionExit - ����������, ����� ������, �� ������� ����� ������, ������� (��������� �������������) � ������ �����������
*/