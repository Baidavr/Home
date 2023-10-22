using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDron : MonoBehaviour
{
    // [SerializeField]
    [SerializeField] Transform Point1;
    [SerializeField] Transform Point2;
    [SerializeField] float Speed;

    [SerializeField] Transform Dron1;

    private void OnValidate()
    {
        // ���� �������� < 0.00001f, �� ������������ �� � 0.00001f
        // ���� �������� > 1000f, �� ������������ �� � 1000f
        // (0.00001f, 1000f)
        Speed = Mathf.Clamp(Speed, 0.00001f, 1000f);
    }

    void Update()
    {
        float PingPong = Mathf.PingPong(Time.time * Speed, 1);
        // ��� PingPong ������, ��� ����� � Point1
        // ��� PingPong ������, ��� ����� � Point2
        Vector3 position = Vector3.Lerp(Point1.position, Point2.position, PingPong);
        // ((5; 2) + (3; 6)) / 2 = (4; 4)
        // ���������� ������� ����� �� ����� ����� Point1, Point2
        Dron1.position = position;
    }
}
