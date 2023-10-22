using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] - делает видимым поле в инспекторе (правой части юнити)
    // player и direction назначаютс€ из инспектора unity
    [SerializeField] Vector3 _direction;
    [SerializeField] Transform _player;

    /*
    Start - метод, вызывающийс€ в начале игры один раз (в начале сцены)
    Update - метод, вызывающийс€ каждый кадр (кол-во FPS = кол-во вызовов метода)
    FixedUpdate - метод, вызывающийс€ каждую 0.02 секунды (50 раз в секунду)
    */

    void Start()
    {

    }

    
    void FixedUpdate()
    {
        // из игрока вызываем метод Translate. ¬ параметры метода передаем направление движени€ (и силу)
        _player.Translate(_direction);
    }
}


// переменна€ - коробка, хран€ща€ одно значение определенного типа. ѕеременна€ должна создаватьс€ внутри метода (local) (локальна€ переменна€)
// поле - коробка, хран€ща€ одно значение определенного типа. ѕеременна€ должна создаватьс€ вне метода (global) (глобальна€ переменна€)