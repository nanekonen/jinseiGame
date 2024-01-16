using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEditor;


public class LoveDeclarationEvent
{
    public const int LOVE_DECLARATION_THRESHOLD = 70;

    public const string csvPath = "confession";

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

        yield return KeyManager.keyManager.waitForSpace();
        string g = Gender.MAN == player.pi.gender ? "boy" : "girl";
        string[] n = { player.name, highestLover.getName(), "ナレーション", "選択" };
        ProgressUI.progressUI.setLove(ForcedEvent.background[3], highestLover.getNormal(), "", "ナレーション");
        AsyncOperationHandle<TextAsset> a = Addressables.LoadAssetAsync<TextAsset>(csvPath + g + ".csv");
        yield return a.Task;
        StreamReader sr = new StreamReader(a.Result.text);
        sr.ReadLine(); string AorB = "";
        while (!sr.EndOfStream)
        {
            string[] l = sr.ReadLine().Split(',');
            string se = l[1];
            for (int i = 0; i < int.Parse(l[2]) - 1; i++)
            {
                se += "\n" + sr.ReadLine().Split(',')[1];
            }
            ProgressUI.progressUI.setLove_sentence_name(se, n[int.Parse(l[0])]);
            if (l[0] == "3")
            {
                IEnumerator waitForAOrB = KeyManager.keyManager.waitForAOrB();
                yield return waitForAOrB;
                AorB = (string)waitForAOrB.Current;
                break;
            }
            else
            {
                yield return KeyManager.keyManager.waitForSpace();
            }

        }
        a = Addressables.LoadAssetAsync<TextAsset>(csvPath + g + AorB + ".csv");
        yield return a.Task;
        if (AorB.Equals("B"))
        {
            player.pi.partner = highestLover;
            ProgressUI.progressUI.changeTurn(player);
        }
        sr = new StreamReader(a.Result.text);
        while (!sr.EndOfStream)
        {
            string[] l = sr.ReadLine().Split(',');
            string se = l[1];
            for (int i = 0; i < int.Parse(l[2]) - 1; i++)
            {
                se += "\n" + sr.ReadLine().Split(',')[1];
            }
            ProgressUI.progressUI.setLove_sentence_name(se, n[int.Parse(l[0])]);
            yield return KeyManager.keyManager.waitForSpace();
        }
        ProgressUI.progressUI.beingSugoroku();
    }
}
