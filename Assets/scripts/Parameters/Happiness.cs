using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness
{
    public static readonly Happiness UNDEFINED_HAPPINESS = new Happiness();

    public const int MIN = 0;
    public const int MAX = 100;

    public const int UNDEFINED = -1;

    private int value = UNDEFINED;

    public Happiness(int value)
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

    private Happiness()
    {
        this.value = UNDEFINED;
    }

    public int getValue()
    {
        return this.value;
    }

    public void updata(PlayerInformation pi)
    {

    }
}
