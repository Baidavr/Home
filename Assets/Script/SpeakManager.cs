using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeakManager : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    [SerializeField] TMP_Text asnwer1;
    [SerializeField] TMP_Text asnwer2;
    [SerializeField] TMP_Text asnwer3;

    [SerializeField] GameObject Panel;

    bool inSpeakZone;
    Phrases phrases;


    public void TurnOffSpeakPanel()
    {
        Panel.SetActive(false);

    }
    public void TurnOnSpeakPanel()
    {
        Panel.SetActive(true);

    }


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
        if (other.transform.tag == "SpeakZone")
        {
            inSpeakZone = true;
            phrases = other.GetComponentInParent<Phrases>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // создание переменной: <тип_хранимого_значени€> <им€_переменной>;
        if (inSpeakZone)
        {
            // ¬вод.ѕолучить лавишу¬низ(Ќомера нопок.≈)
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnSpeakPanel();
                ShowConversation();


            }
        }
    }
    void ShowConversation()
    {
        QuestionAnswersPair phrase = phrases.Conversation();

        if (phrase.Answers.Length > 0)
        {
            asnwer1.text = phrase.Answers[0];
        }
        else
        {
            asnwer1.text = "";
        }

        if (phrase.Answers.Length > 1)
        {
            asnwer2.text = phrase.Answers[1];
        }
        else
        {
            asnwer2.text = "";
        }

        if (phrase.Answers.Length > 2)
        {
            asnwer3.text = phrase.Answers[2];
        }
        else
        {
            asnwer3.text = "";
        }

        text.text = phrase.phrase;
    }

    public void click(int ButtonIndex)
    {
        QuestionAnswersPair pair = phrases.Conversation();

        if (pair.nextQuestion.Length > ButtonIndex)
        {
            QuestionAnswersPair nextQuestion = pair.nextQuestion[ButtonIndex];
            phrases.SetConversation(nextQuestion);

            ShowConversation();
        }
    }
}
