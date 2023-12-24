using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public RectTransform rect;
    public TextMeshProUGUI name;
    public TextMeshProUGUI per;

    public void setName(string n)
    {
        name.text = n;
        Vector2 v = rect.sizeDelta;
        v.x = n.Length * name.fontSize + 10 + 40;
        rect.sizeDelta = v;
    }

    public void setParameter(int i)
    {
        per.text = i.ToString("0");
        
    }
}
