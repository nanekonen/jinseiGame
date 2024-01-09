using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoverUI : SubjectUI
{
    public RectTransform rect;
    public Image image;

    public void setLover(Lover l,int i,Color c)
    {
        image.color = c;
        setIcon(l.getIcon());
        setName(l.getName());
        setPercent(i);
    }
}
