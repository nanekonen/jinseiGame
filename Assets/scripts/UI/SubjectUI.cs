using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubjectUI : PartsUI
{
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI per;

    public void setIcon(Sprite s)
    {
        icon.sprite = s;
    }

    public void setPercent(int i)
    {
        per.text = i.ToString("0");
    }

    public void setName(string n)
    {
        name.text = n;
    }
}
