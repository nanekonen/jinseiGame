using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccountUI : PartsUI
{
    public Image icon;
    public Image back;
    public List<Image> affiliate = new List<Image>();
    public RectTransform account;
    public TextMeshProUGUI name;

    public override void turnOn()
    {
        
    }

    public void change(PlayerInformation pi)
    {

    }
}
