using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI per;

    public void setName(string n)
    {
        name.text = n;
    }

    public void setParameter(int i)
    {
        per.text = i.ToString("0");
    }
}
