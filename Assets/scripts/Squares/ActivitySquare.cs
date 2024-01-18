using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ActivitySquare : Square
{
    private List<string> sentence;
    private List<int> favorability;
    private List<string> nameOfLovers;

    private Player player;
    // Start is called before the first frame updateValue
    public ActivitySquare(List<string> sentence, List<int> favorability, List<string> nameOfLovers)
    {
        this.id = 1;
        this.sentence = sentence;
        this.favorability = favorability;
        this.nameOfLovers = nameOfLovers;
    }
    public override IEnumerator execute(Player player)
    {
        Debug.Log("execution");
        this.player = player;

        if(player.pi.activity == Activity.UNDEFINED){
            ProgressUI.progressUI.setInstructionSpace("activityが未定義");
        }else{
            player.pi.lovers.getLoverByName(nameOfLovers[(int)player.pi.activity*2 + (int)player.pi.gender]).fav.add(favorability[(int)player.pi.activity]);
            ProgressUI.progressUI.setInstructionSpace(
                sentence[(int)player.pi.activity].
                Replace("Name",nameOfLovers[(int)player.pi.activity*2 + Math.Abs((int)player.pi.gender-1)]));
        }

        yield break;
    }
}