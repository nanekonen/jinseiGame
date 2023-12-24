using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;


public class LoveDeclarationEvent
{
    public const int LOVE_DECLARATION_THRESHOLD = 70;
    public LoveDeclarationEvent()
    {

    }

    public IEnumerator execute(Player player)
    {
        Lover highestLover = player.pi.lovers.getHightestLover();
        int favorability = highestLover.fav.getValue();

        if (favorability < LOVE_DECLARATION_THRESHOLD)
        {
            yield break;
        }

        ProgressUI.progressUI.setInstructionSpace
        (
            "実は私あなたのことが好きだったの。\n付き合ってくれない？"
        );

        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setInstructionSpace
        (
            "A. もちろんいいよ。\nB.　きも"
        );

        IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
        yield return waitForAOrB;
        string AorB = (string)waitForAOrB.Current;

        if (AorB == "A")
        {
            player.pi.lover = highestLover;
            ProgressUI.progressUI.setInstructionSpace
            (
                "こうして二人はめでたく結ばれましたとさ。"
            );
        }
        else
        {
            ProgressUI.progressUI.setInstructionSpace
            (
                "この変態！！"
            );
        }

        


    }
}
