using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorabilityUI : PartsUI
{
    public List<SubjectUI> subjects;

    public void setLovers(Lovers l)
    {
        List<string> n = l.getAllLoverName();
        for(int i0 = 0;i0 < subjects.Count; i0++)
        {
            Lover lo = l.getLoverByName(n[i0]);
            subjects[i0].setIcon(lo.getIcon());
            subjects[i0].setName(n[i0]);
            subjects[i0].setPercent(lo.fav.getValue());
        }
    }
    public void setPercent(Lover l)
    {
        foreach(SubjectUI s in subjects)
        {
            if(s.name.text == l.getName())
            {
                s.setPercent(l.fav.getValue());
                break;
            }
        }
    }
}
