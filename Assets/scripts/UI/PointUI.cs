using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointUI : PartsUI
{
    public TextMeshProUGUI par;
    public RectTransform rect;

    public void setParameter(int i)
    {
        par.text = i.ToString("0");
    }
}
