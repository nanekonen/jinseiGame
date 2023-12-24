using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance
{
    public static readonly Performance UNDEFINED_PERFORMANCE = new Performance();

    public const int MIN = 0;
    public const int MAX = 100;

    public const int UNDEFINED = -1;

    private int value = UNDEFINED;

    public Performance(int value)
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

    private Performance()
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
