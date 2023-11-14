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
        // из transform берем tag, который был получен из other
        // . - принадлежность
        if (other.transform.tag == "SpeakZone")
        {
            inSpeakZone = false;
            phrases = null;
        }
    }
    // other - коллайдер, с которым столкнулс€ персонаж
    private void OnTriggerEnter(Collider other)
    {
        // из transform берем tag, который был получен из other
        // . - принадлежность
        if(other.transform.tag == "SpeakZone")
        {
            inSpeakZone = true;
            phrases = other.GetComponentInParent<Phrases>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // создание переменной: <тип_хранимого_значени€> <им€_переменной>;
        if(inSpeakZone)
        {
            // ¬вод.ѕолучить лавишу¬низ(Ќомера нопок.≈)
            if (Input.GetKeyDown(KeyCode.E))
            {
                string phrase = phrases.Conversation();
                // вывести фразу в текст канваса
                
                text.text = phrase;
            }
        }
    }
}
