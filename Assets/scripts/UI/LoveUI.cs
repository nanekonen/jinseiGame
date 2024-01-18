using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoveUI : PartsUI
{
    public Image background;

    public Image subject;
    public AspectRatioFitter arf;

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
        v.x = 100 + n.Length * name.fontSize;
        rect.sizeDelta = v;
        name.text = n;
    }

    public void changeBackGround(Sprite s)
    {
        background.sprite = s;
    }

    public void changeSubject(Sprite s)
    {
        subject.sprite = null;
        subject.sprite = s;
        arf.aspectRatio = s.rect.width / s.rect.height;
    }
}
