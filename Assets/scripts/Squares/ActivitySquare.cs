using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivitySquare : Square
{
    private List<string> sentence;
    private List<int> academic;
    private List<int> appearance;
    private List<int> luck;
    private List<int> favorability;

    private Player player;
    // Start is called before the first frame update
    public ActivitySquare(List<string> sentence, List<int> academic, List<int> appearance, List<int> luck, List<int> favorability)
    {
        this.sentence = sentence;
        this.academic = academic;
        this.appearance = appearance;
        this.luck = luck;
        this.favorability = favorability;
    }
    public override void execute(Player player)
    {
        Debug.Log("execution");
        this.player = player;

        if(player.pi.activity == Activity.UNDEFINED){
            ProgressUI.progressUI.setInstructionSpace("activityが未定義");
        }else{
            player.pi.academic.add(academic[(int)player.pi.activity]);
            player.pi.appearance.add(appearance[(int)player.pi.activity]);
            player.pi.luck.add(luck[(int)player.pi.activity]);
            player.pi.lovers.getLoverByActivity(player.pi.activity).fav.add(favorability[(int)player.pi.activity]);
            ProgressUI.progressUI.setInstructionSpace(sentence[(int)player.pi.activity]);
        }
        
    }
}