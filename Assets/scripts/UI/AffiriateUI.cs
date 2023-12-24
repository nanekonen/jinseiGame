using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffiriateUI : PartsUI
{
    public List<Image> list;
    public RectTransform rect;

    public void setAffiriation(Activity a)
    {
        foreach(Image i in list)
        {
            i.enabled = false;
        }
        list[a == Activity.BASKET ? 0 : a == Activity.BRASS_BAND ? 1 : 2].enabled = true;
    }
}
