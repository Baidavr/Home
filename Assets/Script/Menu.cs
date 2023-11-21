using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button Играть;
    [SerializeField] Button Перезапустить;
    [SerializeField] Button Выход;
    [SerializeField] Button Настройки;
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        Выход.onClick.AddListener(Exit);
        Перезапустить.onClick.AddListener(Restart);
        Играть.onClick.AddListener(TwoStart);
    }

    void Restart()
    {
        // 1. получить активную сцену
        // 2. получить индекс/имя сцены
        // 3. загрузить сцену по ее индексу или имени

        // Get - получить
        // Active - активную
        // Scene - сцену
        string Scene = SceneManager.GetActiveScene().name;
        // Load - загрузить
        // Scene - сцену
        SceneManager.LoadScene(Scene);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void TwoStart()
    {
        SceneManager.LoadScene(0);
    }


    void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        // нажата ли кнопка esc?
        // если да, то...
        // выключить или выключить канвас
        // иначе проигнорировать

        bool Esc = Input.GetKeyDown(KeyCode.Escape);

        if(Esc)
        {
            canvas.enabled = !canvas.enabled;  //enabled - включено ли

            // -(-(-5)) -> -5
            // !true -> false
            // !false -> true
        }
    }
}
