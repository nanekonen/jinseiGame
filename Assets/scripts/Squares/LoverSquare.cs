using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LoverSquare : Square
{
    private List<string> sentence;
    private List<int> favorability;
    private List<string> nameOfLovers;
    private string partnerSentence;
    private int partnerFavorability;

    private Player player;
    // Start is called before the first frame update
    public LoverSquare(List<string> sentence, List<int> favorability, List<string> nameOfLovers, string partnerSentence, int partnerFavorability)
    {
        this.id = 2;
        this.sentence = sentence;
        this.favorability = favorability;
        this.nameOfLovers = nameOfLovers;
        this.partnerSentence = partnerSentence;
        this.partnerFavorability = partnerFavorability;
    }
    public override void execute(Player player)
    {
        Debug.Log("execution");
        this.player = player;
        string targetLoverName = nameOfLovers[(int)player.pi.activity + Math.Abs((int)player.pi.gender - 1)];
        int referenceFavorability = favorability[(int)player.pi.activity];

        if (player.pi.activity == Activity.UNDEFINED)
        {
            ProgressUI.progressUI.setInstructionSpace("activityが未定義");
        }
        else if (player.pi.partner != Lover.UNDEFINED && player.pi.partner.getName() != targetLoverName)//彼氏彼女マス(他の恋愛対象のマス内容の場合は差し替える)
        {
            player.pi.partner.fav.add(partnerFavorability);
            ProgressUI.progressUI.setInstructionSpace
                (
                partnerSentence +
                player.pi.partner + "の好感度が" + Math.Abs(partnerFavorability) +
                ((referenceFavorability > 0) ? "上がった。" : "下がった。")
                );
        }
        else
        {
            player.pi.lovers.getLoverByName(targetLoverName).fav.add(referenceFavorability);//好感度上下マス(彼氏彼女問わず)
            ProgressUI.progressUI.setInstructionSpace
                (
                sentence[(int)player.pi.activity] +
                targetLoverName + "の好感度が" + Math.Abs(referenceFavorability) +
                ((referenceFavorability > 0) ? "上がった。" : "下がった。")
                );
        }

        if (player.pi.partner != Lover.UNDEFINED && player.pi.partner.fav.getValue() < 30)//振られるイベント
        {
            player.pi.partner = Lover.UNDEFINED;
            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.partner.getName() + ":「ごめん別れよ」 \n" +
                player.pi.partner.getName() + "と別れました。"
                );
        }
    }
}