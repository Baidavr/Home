using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float VerticalInput;

    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
    }
}
