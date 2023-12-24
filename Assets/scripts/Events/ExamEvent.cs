using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class ExamEvent
{

    private Questions questions;

    public ExamEvent():base()
    {
        questions = new Questions("exam.csv");
            
    }

    public IEnumerator execute(Season season, Round round, Players players)
    {
         Debug.Log("this is from spring force event");

        if (season.getID() != Season.SPRING) yield break;
        if (round.getRound() != 5) yield break;

        for( int j = 0; j < Players.numberOfPlayer; j++ )
        {
            Player player = players.getPlayer(j);

            ProgressUI.progressUI.changeTurn(player);

            ProgressUI.progressUI.setInstructionSpace("定期テストが始まりました。！！問題に答えてね");
            yield return KeyManager.keyManager.waitForSpace();


            for (int i = 0; i < 5; i++)
            {
                Question question = questions.getQuestion(i);
                ProgressUI.progressUI.setInstructionSpace(question.generateQuestionText(i));

                IEnumerator ans = KeyManager.keyManager.waitFor1Or2Or3();
                yield return ans;
                int answer = (int)ans.Current;

                bool isCorrect = question.isCorrect(answer);

                ProgressUI.progressUI.setInstructionSpace("次の問題へ。push the space key.");
                yield return KeyManager.keyManager.waitForSpace();
            }

            double luck = (double)player.pi.luck.getValue() / 100.0f;
            double academic = (double)player.pi.academic.getValue();
            double correctAnsNum = (double)questions.getCorrectAnswerCount();
            int grades = (int)(luck * academic * correctAnsNum);

            ProgressUI.progressUI.setInstructionSpace("あなたの成績は" + grades.ToString() + "です。");
            yield return KeyManager.keyManager.waitForSpace();

        }


    }



}
