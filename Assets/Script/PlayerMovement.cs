using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] - ������ ������� ���� � ���������� (������ ����� �����)
    // player � direction ����������� �� ���������� unity
    [SerializeField] Vector3 _direction;
    [SerializeField] Transform _player;

    /*
    Start - �����, ������������ � ������ ���� ���� ��� (� ������ �����)
    Update - �����, ������������ ������ ���� (���-�� FPS = ���-�� ������� ������)
    FixedUpdate - �����, ������������ ������ 0.02 ������� (50 ��� � �������)
    */

    void Start()
    {

    }

    
    void FixedUpdate()
    {
        // �� ������ �������� ����� Translate. � ��������� ������ �������� ����������� �������� (� ����)
        _player.Translate(_direction);
    }
}


// ���������� - �������, �������� ���� �������� ������������� ����. ���������� ������ ����������� ������ ������ (local) (��������� ����������)
// ���� - �������, �������� ���� �������� ������������� ����. ���������� ������ ����������� ��� ������ (global) (���������� ����������)