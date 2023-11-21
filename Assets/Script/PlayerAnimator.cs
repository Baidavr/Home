using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Rigidbody
    // Animator
    // коэфицент скорости анимации

    [SerializeField]  Rigidbody rb;
    [SerializeField] Animator Anim;
    [SerializeField] float Speed;

   
    void Update()
    {
        Anim.SetFloat("Speed", rb.velocity.magnitude * Speed);
    }
}
