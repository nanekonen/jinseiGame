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
    public LoverSquare(List<string> sentence, List<int> favorability, List<string> nameOfLovers , string partnerSentence ,int partnerFavorability)
    {
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

        if (player.pi.activity == Activity.UNDEFINED){
            ProgressUI.progressUI.setInstructionSpace("activityが未定義");
        }
        else if (player.pi.lover != Lover.UNDEFINED && player.pi.lover.getName() != targetLoverName)//彼氏彼女マス(他の恋愛対象のマス内容の場合は差し替える)
        {
            player.pi.lover.fav.add(partnerFavorability);
            ProgressUI.progressUI.setInstructionSpace
                (
                partnerSentence.Replace("Name", player.pi.lover.getName())
                );
        }
        else{
            player.pi.lovers.getLoverByName(targetLoverName).fav.add(favorability[(int)player.pi.activity]);//好感度上下マス(彼氏彼女問わず)
            ProgressUI.progressUI.setInstructionSpace
                (
                sentence[(int)player.pi.activity].Replace("Name",targetLoverName)
                );
        }

        if (player.pi.lover != Lover.UNDEFINED && player.pi.lover.fav.getValue() < 30)//振られるイベント
        {
            player.pi.lover = Lover.UNDEFINED;
            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.lover.getName() + ":「ごめん別れよ」 "
                );
            ProgressUI.progressUI.setInstructionSpace
                (
                player.pi.lover.getName() + "と別れました。"
                );
        }
    }
}