using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RankUI : PartsUI
{
    public List<Score> ranking;

    private bool rank = false;

    public bool getRank()
    {
        return rank;
    }
    public void updateValue(List<PlayerInformation> pi_list)
    {
        rank = true;
        pi_list = pi_list.OrderBy(s => s.happiness.getValue()).ToList();
        pi_list.Reverse();
        for(int i0 = 0;i0 < ranking.Count; i0++)
        {
            ranking[i0].setName(pi_list[i0].name);
            ranking[i0].setParameter(pi_list[i0].happiness.getValue());
        }
    }
}
