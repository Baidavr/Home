using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Acceleration;
    [SerializeField] float MaxSpeed;
    [SerializeField] float SpeedJump;
    [SerializeField] float RotationSpeed;
    [SerializeField] float RotationSpeedY;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Camera;
    [SerializeField] Jump _jump;

    float CurSpeed;


    private void Start()
    {
        CurSpeed = MaxSpeed;
    }

    void Update()
    {
        ChiftControl();

        Move();  //вызов метода,который управляет движением объекта

        Rotate();  //вызов метода,который управляет вращением объекта

        Jump();
    }

    private void Jump()
    {
        // если
        // Нажата клавиша пробела,
        // то направление игрока по Y = 5

        // если(Ввод.НажатаЛиКлавиша(НомерКлавиши.Пробел)) { ... }
        // и прыжок.НаЗемлеЛи == да
        if (Input.GetKeyDown(KeyCode.Space) && _jump.IsGrounded == true)
        {
            Vector3 jump = rb.velocity;
            jump.y = SpeedJump;
            rb.velocity = jump;
        }
    }

    private void ChiftControl()
    {
        // GetKey - зажатие клавиши
        // GetKeyDown - нажатие на клавишу
        // GetKeyUp - отжатие клавиши
        // || - или (два bool)
        // T == T - T
        // F == T - F
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            CurSpeed = MaxSpeed * 2.5f;
        }
        else
        {
            CurSpeed = MaxSpeed;
        }
        // если shift нажат, то CurSpeed = MaxSpeed * 1.5
        // если не нажат, то CurSpeed = MaxSpeed
    }

    private void Move()
    {
        float hor = Input.GetAxis("Horizontal"); // получение данных ввода от пользователя по горизонтальной оси A и D
        float ver = Input.GetAxis("Vertical"); //  получение данных ввода от пользователя по горизонтальной оси W и S

        // forward - перед -         -forward - backward - назад
        // right - направо -         -right - left - налево
        rb.AddForce(transform.forward * Acceleration * Time.deltaTime * ver);
        rb.AddForce(transform.right * Acceleration * Time.deltaTime * hor);

        SpeedControl();


        /*Vector3 velocity = rb.velocity;
        // -MaxSpeed < x < MaxSpeed
        velocity.x = Mathf.Clamp(velocity.x, -MaxSpeed, MaxSpeed);
        velocity.z = Mathf.Clamp(velocity.z, -MaxSpeed, MaxSpeed);
        rb.velocity = velocity;*/


        // rb.velocity.x = Mathf.Clamp(rb.velocity.x, -MaxSpeed, MaxSpeed);
        // rb.velocity.z = Mathf.Clamp(rb.velocity.z, -MaxSpeed, MaxSpeed);
    }

    // контроль скорости, проверяет, что игрок не двигался слишком быстро
    private void SpeedControl()
    {
        // (1, 0.5, 2)
        // (2, 1, 4)

        // записываем во flatVel новый вектор состоящий из x и z velocity игрока, но Y=0
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // если магнитуда (длина) вектора больше максимальной скорости, то...
        if (flatVel.magnitude > CurSpeed)
        {
            // (2; 5; 3) / 38 = (0.0526, 0.13157, 0,0789) = (0.263, 0.65785, 0.3945)
            // находим нормаль вектора и умножаем ее на максимальную скорость. Получаем обрезанную скорость игрока
            Vector3 limitedVel = flatVel.normalized * CurSpeed;
            // назначем уменьшеенную скорость игроку, сохраняя при этом ее направление и скорость по оси Y
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * RotationSpeed * Time.deltaTime, 0);

        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 Rotation = Camera.localRotation.eulerAngles;
        // rot.x = rot.x - mouseY
        // Clamp - обрезает число между двумя границами, принимает число, минимальное и максимальное значение
        // clamp(5, 2, 6) = 5
        // clamp(1, 3, 7) = 3
        // clamp(-1, -3, -7) = -3
        // clamp(10, 3, 5) = 5
        //Rotation.x = Mathf.Clamp(Rotation.x - mouseY * RotationSpeed * Time.deltaTime, , );
        Rotation.x = Rotation.x - mouseY * RotationSpeedY * Time.deltaTime;
        if (Rotation.x > 180)
        {
            Rotation.x = Mathf.Clamp(Rotation.x, 360 - 70, 361);
        }
        else if (Rotation.x < 180)
        {
            Rotation.x = Mathf.Clamp(Rotation.x, -1, 45);
        }
        Camera.localRotation = Quaternion.Euler(Rotation);
    }
}


// переменная - коробка, хранящая одно значение определенного типа. Переменная должна создаваться внутри метода (local) (локальная переменная)
// поле - коробка, хранящая одно значение определенного типа. Переменная должна создаваться вне метода (global) (глобальная переменная)