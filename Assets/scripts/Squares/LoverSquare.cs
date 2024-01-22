using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LoverSquare : Square
{
    private List<string> sentence;//部活バイトマスの表示文
    private List<int> favorability;//部活バイトマスの好感度変化値
    private List<string> nameOfLovers;
    private string partnerSentence;//彼氏彼女マスの表示文
    private int partnerFavorability;//彼氏彼女マスの好感度変化値
    private string ickSentence;//蛙化マスの表示文
    System.Random r = new System.Random();

    private Player player;
    // Start is called before the first frame update
    public LoverSquare(List<string> sentence, List<int> favorability, List<string> nameOfLovers, string partnerSentence, int partnerFavorability, string ickSentence)
    {
        this.id = 2;
        this.sentence = sentence;
        this.favorability = favorability;
        this.nameOfLovers = nameOfLovers;
        this.partnerSentence = partnerSentence;
        this.partnerFavorability = partnerFavorability;
        this.ickSentence = ickSentence;
    }
    public override IEnumerator execute(Player player)
    {
        Debug.Log("execution");
        this.player = player;
        string targetLoverName = nameOfLovers[((int)player.pi.activity * 2) + Math.Abs((int)player.pi.gender - 1)];
        int referenceFavorability = favorability[(int)player.pi.activity];


        if (player.pi.activity == Activity.UNDEFINED)
        {
            ProgressUI.progressUI.setInstructionSpace("activityが未定義");
        }
        else if (player.pi.partner != Lover.UNDEFINED && player.pi.partner.getName() != targetLoverName)//彼氏彼女マスもしくは蛙化マス(他の恋愛対象のマス内容の場合に差し替える)
        {
            if(30 > r.Next(0, 100))//30%で蛙化マス実行
            {
                int ickFavoreability = r.Next(-80, -40);
                player.pi.partner.fav.add(ickFavoreability);

                ProgressUI.progressUI.setInstructionSpace
                    (
                    ickSentence
                    );

                yield return KeyManager.keyManager.waitForSpace();

                ProgressUI.progressUI.setInstructionSpace
                    (
                    player.pi.partner.getName() + "の好感度が" +
                    Math.Abs(ickFavoreability) +
                    ((ickFavoreability > 0) ? "上がった。" : "下がった。")
                    );
            }
            else//彼氏彼女マス実行
            {
                player.pi.partner.fav.add(partnerFavorability);

                ProgressUI.progressUI.setInstructionSpace
                    (
                    partnerSentence
                    );

                yield return KeyManager.keyManager.waitForSpace();

                ProgressUI.progressUI.setInstructionSpace
                    (
                    player.pi.partner.getName() + "の好感度が" +
                    Math.Abs(partnerFavorability) +
                    ((partnerFavorability > 0) ? "上がった。" : "下がった。")
                    );
            }
        }
        else//好感度上下マス(彼氏彼女問わず)
        {
            player.pi.lovers.getLoverByName(targetLoverName).fav.add(referenceFavorability);

            ProgressUI.progressUI.setInstructionSpace
                (
                sentence[(int)player.pi.activity].Replace("HEorSHE", (player.pi.gender == Gender.MAN) ? "彼女" : "彼")
                );

            yield return KeyManager.keyManager.waitForSpace();

            ProgressUI.progressUI.setInstructionSpace
                (
                targetLoverName + "の好感度が" + Math.Abs(referenceFavorability) +
                ((referenceFavorability > 0) ? "上がった。" : "下がった。")
                );
        }

        if (player.pi.partner != Lover.UNDEFINED && player.pi.partner.fav.getValue() < 30)//振られるイベント
        {
            yield return KeyManager.keyManager.waitForSpace();

            yield return BreakUp.execute(player);

            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() +
                "と別れました."
                );
            player.pi.partner = Lover.UNDEFINED;
        }
        yield return null;
    }
}