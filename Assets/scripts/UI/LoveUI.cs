using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoveUI : PartsUI
{
    public Image background;

    public RectTransform rect;
    public TextMeshProUGUI name;

    public SentenceUI sentenceUI;

    public void changeSentence(string t)
    {
        sentenceUI.change(t);
    }

    public void changeName(string n)
    {
        Vector2 v = rect.sizeDelta;
        v.y = 20 + n.Length * name.fontSize;
        rect.sizeDelta = v;
        name.text = n;
    }

    public void changeBackGround(Sprite s)
    {
        background.sprite = s;
    }
}
