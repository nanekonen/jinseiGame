using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconUI : PartsUI
{
    public Image back;
    public Image icon;

    public void change(Sprite s)
    {
        icon.sprite = s;
    }
    public override void turnOn()
    {
        back.enabled = true;
        icon.enabled = true;
    }

    public override void turnOff()
    {
        back.enabled = false;
        back.enabled = false;
    }
}
