using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSeason : SeasonSquares
{

    public override List<Square> changeOfSquares(List<RealSquare> rsquares)
    {
        List<Square> sl = new List<Square>();
        for(int i = 0;i < Season.lengthOfSeason; i++)
        {
            Square s = new TestSquare("未成年者喫煙をした.学力と容姿と運が1ずつ下がった", -1, -1, -1);
            sl.Add(s);
        }
        return sl;
    }
}
