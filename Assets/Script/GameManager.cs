using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    InputManager input;

    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.AddComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
