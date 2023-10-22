using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float VerticalInput;

    void Update()
    {
        // инкапсул€ци€

        VerticalInput = Input.GetAxis("Vertical");
    }
}
