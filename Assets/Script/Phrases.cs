using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrases : MonoBehaviour
{
    [SerializeField] QuestionAnswersPair phrases;

    public QuestionAnswersPair Conversation()
    {
        return phrases;
    }

    public void SetConversation(QuestionAnswersPair conversation)
    {
        phrases = conversation;
    }
}
