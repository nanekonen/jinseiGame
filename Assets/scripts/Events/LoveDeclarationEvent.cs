using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using UnityEditor;


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
            ProgressUI.progressUI.beingSugoroku();
            yield break;
        }

        /*
        ProgressUI.progressUI.setInstructionSpace
        (
            "実は私あなたのことが好きだったの。\n付き合ってくれない？"
        );
        */

        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setLove_sentence
        (
            "A. もちろんいいよ。\nB.　きも"
        );

        IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
        yield return waitForAOrB;
        string AorB = (string)waitForAOrB.Current;

        if (AorB == "A")
        {
            player.pi.partner = highestLover;
            ProgressUI.progressUI.setLove_sentence
            (
                "こうして二人はめでたく結ばれましたとさ。"
            );
        }
        else
        {
            ProgressUI.progressUI.setLove_sentence
            (
                "この変態！！"
            );
        }


        ProgressUI.progressUI.beingSugoroku();
    }
}
