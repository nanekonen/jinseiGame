using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverUI : SubjectUI
{
    public RectTransform rect;

    public void setLover(Lover l,int i)
    {
        setIcon(l.getIcon());
        setName(l.getName());
        setPercent(i);
    }
}
