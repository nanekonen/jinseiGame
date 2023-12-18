using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameUI : PartsUI
{
    public RectTransform name;
    public Image back;
    public TextMeshProUGUI text;

    public void change(string n)
    {
        text.text = n;
        
    }
    public override void turnOn()
    {
        back.enabled = true;
        text.enabled = true;
    }

    public override void turnOff()
    {
        back.enabled = false;
        text.enabled = false;
    }
}
