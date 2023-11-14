using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeakManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    bool inSpeakZone;
    Phrases phrases;

    private void OnTriggerExit(Collider other)
    {
        // �� transform ����� tag, ������� ��� ������� �� other
        // . - ��������������
        if (other.transform.tag == "SpeakZone")
        {
            inSpeakZone = false;
            phrases = null;
        }
    }
    // other - ���������, � ������� ���������� ��������
    private void OnTriggerEnter(Collider other)
    {
        // �� transform ����� tag, ������� ��� ������� �� other
        // . - ��������������
        if(other.transform.tag == "SpeakZone")
        {
            inSpeakZone = true;
            phrases = other.GetComponentInParent<Phrases>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ����������: <���_���������_��������> <���_����������>;
        if(inSpeakZone)
        {
            // ����.�������������������(������������.�)
            if (Input.GetKeyDown(KeyCode.E))
            {
                string phrase = phrases.Conversation();
                // ������� ����� � ����� �������
                
                text.text = phrase;
            }
        }
    }
}
