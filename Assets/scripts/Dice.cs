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

    public void setCallback(DiceCallback callback)
    {
        this.diceCallback = callback;
        KeyManager.keyManager.setDownSpace(spacekeyCallback);
        
    }

    private void spacekeyCallback()
    {
        Debug.Log("waitDice");
        ProgressUI.progressUI.setSpaceTextEnabled();

        int d = Random.Range(1, 6);
        ProgressUI.progressUI.setDiceNumber(d);

        this.diceCallback(d);
    }
}