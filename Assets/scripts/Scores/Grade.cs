using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grade
{
    public static readonly Grade UNDEFINED_GRADE = new Grade();

    public const int MIN = 0;
    public const int MAX = 999; 

    public const int UNDEFINED = -1;

    private int value = UNDEFINED;

    public static Grade GradeFactory(in Player player, in Questions questions)
    {
        double luck = (double)player.pi.luck.getValue() / 100.0f;
        double academic = (double)player.pi.academic.getValue();
        double correctAnsNum = (double)questions.getCorrectAnswerCount();
        int grade = (int)(luck * academic * correctAnsNum);

        return new Grade(grade);
    }
    private Grade(int value)
    {

        int temp_value = value;
        if (temp_value > MAX)
        {
            this.value = MAX;
            return;
        }
        if (temp_value < MIN)
        {
            this.value = MIN;
            return;
        }

        this.value = value;
    }

    private Grade()
    {
        this.value = UNDEFINED;
    }

    public int getValue()
    {
        return this.value;
    }

    public void setValue(int i)
    {
        int temp_value = i;
        if (temp_value > MAX)
        {
            this.value = MAX;
            return;
        }
        if (temp_value < MIN)
        {
            this.value = MIN;
            return;
        }

        this.value = i;
    }
}
