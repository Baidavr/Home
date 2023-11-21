using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // IsGrounded - касается ли земпли

    public bool IsGrounded;

    // параметр - переменная, которая создается между '(' и ')'. Она хранит передаваемое значение из место вызова
    // other = ...
    void OnTriggerStay(Collider other)
    {
        // если 
        // слой (layer) other - это "Ground",
        // то...

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
Start - вызывается при старте сцены (игры)
Update - используется для повторяющихся действия. Вызывается каждый кадр
FixedUpdate - обычно используется для вещей, связанных с физикой. Вызывается 50 раз в секунду

Если коллайдер с включенной галочкой IsTrigger (не оказывает влияния на другие коллайдеры):
OnTriggerEnter - вызывается, когда обьект, на котором висит скрипт, сталкивается с каким-либо другим коллайдером
OnTriggerStay - вызывается, когда обьект, на котором висит скрипт, находится в другом коллайдером
OnTriggerExit - вызывается, когда обьект, на котором висит скрипт, выходит (перестает соприкосаться) с другим коллайдером

Если коллайдер с выключенной галочкой IsTrigger (оказывает влияния на другие коллайдеры):
OnCollisionEnter - вызывается, когда обьект, на котором висит скрипт, сталкивается с каким-либо другим коллайдером
OnCollisionStay - вызывается, когда обьект, на котором висит скрипт, находится в другом коллайдером
OnCollisionExit - вызывается, когда обьект, на котором висит скрипт, выходит (перестает соприкосаться) с другим коллайдером
*/