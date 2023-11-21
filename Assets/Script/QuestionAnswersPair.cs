using System;
using UnityEngine;
// QuestionAnswersPair
// пара из вопроса и ответов

[Serializable] 
public class QuestionAnswersPair
{
    // фраза - вопрос
    public string phrase;

    public string[] Answers;
    public QuestionAnswersPair[] nextQuestion;
}
