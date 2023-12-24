using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class Question
{
    public const int numOfOptions = 3;
    public string questionText { get; private set; }
    public int correctAnswerIndex { get; private set; }

    public bool rightAnswer { get; private set; } = false;


    public List<string> availableAnswers { get; private set; } = new List<string>(); 

    public Question
    (
        string questionText,
        string answer1,
        string answer2,
        string answer3,
        int correctIndex
    )
    {
        this.questionText = questionText;
        availableAnswers.Add( answer1 );
        availableAnswers.Add( answer2 );
        availableAnswers.Add( answer3);
        this.correctAnswerIndex = correctIndex;
    }

    public bool isCorrect(int number)
    {
        if( number - 1 == correctAnswerIndex )
        {
            rightAnswer = true;
            return true;
        }
        else
        {
            rightAnswer = false;
            return false;
        }
    }

    public string generateQuestionText(int questionNumber)
    {
        string text = "";
        text += "Q";
        text += (questionNumber + 1).ToString();
        text += ". ";
        text += questionText;
        text += "\n";

        for( int i = 0; i < numOfOptions; i++ )
        {
            text += (i + 1).ToString();
            text += ". ";
            text += availableAnswers[i];
            text += "\n";
        }

        return text;
    }

}
