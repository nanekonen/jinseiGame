using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSeason : SeasonSquares
{

    public override List<Square> changeOfSquares(List<RealSquare> rsquares)
    {
        List<Square> sl = new List<Square>();
        for(int i = 0;i < GameMain.gameMain.lengthOfSeason; i++)
        {
            Square s = new TestSquare("–¢¬”NŽÒ‹i‰Œ‚ð‚µ‚½.Šw—Í‚Æ—eŽp‚Æ‰^‚ª1‚¸‚Â‰º‚ª‚Á‚½", -1, -1, -1);
            sl.Add(s);
        }
        return sl;
    }
}
