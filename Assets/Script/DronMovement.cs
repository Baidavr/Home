using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronMovement : MonoBehaviour
{
    [SerializeField] Transform Point11;
    [SerializeField] Transform Point22;
    [SerializeField] float Speed;
    [SerializeField] Transform Dron;


    private void OnValidate()
    {
        Speed = Mathf.Clamp(Speed, 0.00001f, 1000f);
    }

    private void Update()
    {
        float PingPong = Mathf.PingPong(Time.time * Speed, 1);
        Vector3 position = Vector3.Lerp(Point11.position, Point22.position, PingPong);
        Dron.position = position;
    }

}