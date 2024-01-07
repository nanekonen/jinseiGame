using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceUI : PartsUI
{
    public List<Image> dices;

    public void rolling(int n)
    {
        foreach(Image i in dices)
        {
            i.enabled = false;
        }
        if(0 < n&&n - 1 < dices.Count)
        {
            dices[n - 1].enabled = true;
        }
    }
}
