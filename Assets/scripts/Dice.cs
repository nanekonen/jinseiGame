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
    public int run()
    {
        int d = Random.Range(1, 3);
        ProgressUI.progressUI.setDiceNumber(d);

        return d;

    }
}