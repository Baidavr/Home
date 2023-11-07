using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Button ������;
    [SerializeField] Button �������������;
    [SerializeField] Button �����;
    [SerializeField] Button ���������;
    [SerializeField] Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        �����.onClick.AddListener(Exit);
        �������������.onClick.AddListener(Restart);
        ������.onClick.AddListener(TwoStart);
    }

    void Restart()
    {
        // 1. �������� �������� �����
        // 2. �������� ������/��� �����
        // 3. ��������� ����� �� �� ������� ��� �����

        // Get - ��������
        // Active - ��������
        // Scene - �����
        string Scene = SceneManager.GetActiveScene().name;
        // Load - ���������
        // Scene - �����
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
        // ������ �� ������ esc?
        // ���� ��, ��...
        // ��������� ��� ��������� ������
        // ����� ���������������

        bool Esc = Input.GetKeyDown(KeyCode.Escape);

        if(Esc)
        {
            canvas.enabled = !canvas.enabled;  //enabled - �������� ��

            // -(-(-5)) -> -5
            // !true -> false
            // !false -> true
        }
    }
}
