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
        string[] n = { player.pi.name, highestLover.getName(), "ナレーション", "選択" };
        ProgressUI.progressUI.setLove(ForcedEvent.background[3], highestLover.getNormal(), "", "ナレーション");
        AsyncOperationHandle<TextAsset> a = Addressables.LoadAssetAsync<TextAsset>(csvPath + "/" + g + ".csv");
        yield return a;
        TextAsset ta = a.Result;
        Debug.Log(ta.text);
        string[] sr = a.Result.text.Split('\n');
        int ind = 1;
        string AorB = "";
        while (ind != sr.Length)
        {
            string[] l = sr[ind].Split(',');
            Debug.Log(sr[ind]);
            string se = l[1];
            Debug.Log(l[2]);
            for (int i = 0; i < int.Parse(l[2]) - 1; i++)
            {
                ind++;
                se += "\n" + sr[ind].Split(',')[1];
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
            ind++;
        }
        a = Addressables.LoadAssetAsync<TextAsset>(csvPath + "/" + g + AorB + ".csv");
        yield return a;
        if (AorB.Equals("B"))
        {
            player.pi.partner = highestLover;
            ProgressUI.progressUI.changeTurn(player);
        }
        sr = a.Result.text.Split('\n');
        ind = 1;
        while (ind != sr.Length)
        {
            string[] l = sr[ind].Split(',');
            if(l.Length != 3)
            {
                break;
            }
            string se = l[1];
            Debug.Log(l[2]);
            for (int i = 0; i < int.Parse(l[2]) - 1; i++)
            {
                ind++;
                se += "\n" + sr[ind].Split(',')[1];
            }
            ProgressUI.progressUI.setLove_sentence_name(se, n[int.Parse(l[0])]);
            yield return KeyManager.keyManager.waitForSpace();
            ind++;
        }
        ProgressUI.progressUI.beingSugoroku();
        yield break;
    }
}
