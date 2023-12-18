using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountUI : PartsUI
{
    public RectTransform rect;
    public Image icon;
    public List<Image> affiliate = new List<Image>();
    public TextMeshProUGUI text;

    public void change(PlayerInformation pi)
    {
        Vector2 v2 = rect.sizeDelta;
        v2.x = pi.name.Length * text.fontSize > 15 ? 125 + text.fontSize * pi.name.Length : 140;
        rect.sizeDelta = v2;
        text.text = pi.name;
        foreach(Image i in affiliate)
        {
            i.enabled = false;
        }
        if(pi.activity != Activity.UNDEFINED)
        {
            Activity a = pi.activity;
            affiliate[a == Activity.BASKET ? 0 : a == Activity.BRASS_BAND ? 1 : 2].enabled = true;
        }
        icon.sprite = pi.sprite;
    }
}
