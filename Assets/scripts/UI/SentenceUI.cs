using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceUI : PartsUI
{
    public TextMeshProUGUI text;
    public void change(string s)
    {
        text.text = s;
    }
}
