using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float RotationSpeed;

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 offset = new Vector3(hor, 0, ver) * Speed * Time.deltaTime;
        transform.Translate (offset);

        float yRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, yRotation * RotationSpeed * Time.deltaTime, 0);
    }
}
