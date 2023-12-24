using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountUI : PartsUI
{
    public RectTransform rect;
    public Image icon;
    public AffiriateUI affiriateUI;
    public TextMeshProUGUI text;
    public LoverUI loverUI;
    public PointUI pointUI;

    public void change(PlayerInformation pi)
    {
        int l = 0;
        if(pi.activity != Activity.UNDEFINED)
        {
            affiriateUI.turnOn();
            affiriateUI.setAffiriation(pi.activity);
            Vector2 r = affiriateUI.rect.localPosition;
            r.x = 112.5f;
            affiriateUI.rect.localPosition = r;
            l += 35;
        }
        else
        {
            affiriateUI.turnOff();
        }
        if(pi.lover != Lover.UNDEFINED)
        {
            loverUI.turnOn();
            loverUI.setLover(pi.lover, pi.lovers.getLoverByName(pi.lover.getName()).fav.getValue());
            l += 80 + (l == 35 ? 5:0);
            Vector2 r = loverUI.rect.localPosition;
            loverUI.rect.localPosition = r;
            r.x = 95 + l - 40;
        }
        else
        {
            loverUI.turnOff();
        }
        if (pi.performance != Performance.UNDEFINED_PERFORMANCE)
        {
            pointUI.turnOn();
            pointUI.setParameter(pi.performance.getValue());
            l += 75 + (l >= 35?(l == 120?10:5):0) ;
            Vector2 r = pointUI.rect.localPosition;
            r.x = 95 + l - 37.5f;
            pointUI.rect.localPosition = r;
        }
        else
        {
            pointUI.turnOff();
        }
        Vector2 v2 = rect.sizeDelta;
        v2.x = pi.name.Length * text.fontSize > l - 20 ? 125 + text.fontSize * pi.name.Length : 105 + l;
        rect.sizeDelta = v2;
        text.text = pi.name;
        icon.sprite = pi.sprite;
        
    }
}
