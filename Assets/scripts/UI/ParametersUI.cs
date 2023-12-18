using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParametersUI : PartsUI
{
    public TextMeshProUGUI academic;
    public TextMeshProUGUI appearance;
    public TextMeshProUGUI luck;
    public void change(PlayerInformation pi)
    {
        academic.text = pi.academic.getValue().ToString("0");
        appearance.text = pi.appearance.getValue().ToString("0");
        luck.text = pi.luck.getValue().ToString("0");
    }
}
