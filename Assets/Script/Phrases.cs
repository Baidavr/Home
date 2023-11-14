using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrases : MonoBehaviour
{
    [SerializeField] string[] phrases;
    int phrasesIndex;


    // Update is called once per frame
    public string Conversation()
    {
        phrasesIndex ++;
        return phrases[phrasesIndex - 1];
    }
}
