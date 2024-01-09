using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dice
{
    public delegate void DiceCallback(int dice);
    private DiceCallback diceCallback;
    public Dice()
    {

    }
    public int run(Round r,int p)
    {
        int d = 0;
        List<int> l = new List<int>();
        for(int i = 0;i < 6; i++)
        {
            int f = (int)(r.getRound() / 3) * (int)(i / 3) + (int)(1 - (int)(r.getRound() / 3))*(int)(i / 2)+ 1;
            for(int i1 = 0;i1 < f; i1++)
            {
                l.Add(i + 1);
            }
        }
        do
        {
            d = l[Random.Range(0, l.Count - 1)];
        } while (d + p == 30);

        ProgressUI.progressUI.setDiceNumber(d);
        return d;

    }
}