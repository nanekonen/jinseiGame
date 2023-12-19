using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NowUI : PartsUI
{
    public RectTransform rect;
    public TextMeshProUGUI text;

    public void change(in Player player, in Round round, in Season season)
    {
        //string[] s = { "èt", "âƒ", "èH", "ì~" };
        string[] s = { "spring", "summer", "autumn", "winter" };

        string t =
            s
            [
                season.getID() == Season.UNDEFINED ?
                Season.SPRING :
                season.getID()
            ] +
            ":" +
            round.getRoundInStr() +
            "th";
        Vector2 v = rect.sizeDelta;
        v.x = 20 + text.fontSize * t.Length;
        rect.sizeDelta = v;
        text.text = t;
    }
}
