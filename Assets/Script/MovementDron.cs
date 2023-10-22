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
        // если скорость < 0.00001f, то приравниваем ее к 0.00001f
        // если скорость > 1000f, то приравниваем ее к 1000f
        // (0.00001f, 1000f)
        Speed = Mathf.Clamp(Speed, 0.00001f, 1000f);
    }

    void Update()
    {
        float PingPong = Mathf.PingPong(Time.time * Speed, 1);
        // чем PingPong меньше, тем ближе к Point1
        // чем PingPong больше, тем ближе к Point2
        Vector3 position = Vector3.Lerp(Point1.position, Point2.position, PingPong);
        // ((5; 2) + (3; 6)) / 2 = (4; 4)
        // выставляем позицию дрону на точку между Point1, Point2
        Dron1.position = position;
    }
}
