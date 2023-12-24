using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class Questions
{
    public const string csvDir = "Assets/Resources_moved/Exam/";
    public const int numOfQuestions = 5;

    private System.Random rand = new System.Random();

    private List<Question> questions = new List<Question>();

    public Questions(in string fileName) 
    {
        using (StreamReader reader = new StreamReader(Questions.csvDir + fileName))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                Question question;
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                int correctAnswerIndex = 0;
                int.TryParse(values[4], out correctAnswerIndex);

                question = new Question
                (
                    values[0],
                    values[1],
                    values[2],
                    values[3],
                    correctAnswerIndex
                );

                questions.Add(question); 
            }
        }
    }

    public string getQuestionText(int index)
    {
        return questions[index].generateQuestionText(index);   
    }

    public Question getQuestion(int index) 
    {
        return questions[index];
    }

    public int getCorrectAnswerCount()
    {
        int count = 0; 

        for( int i = 0; i < questions.Count; i++ )
        {
            if(questions[i].rightAnswer)
            {
                count++;
            }
        }

        return count;
    }

    public Question getQuestion()
    {
        int index = rand.Next(0, numOfQuestions);
        return questions[index];
    }
}
