using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public abstract class ForcedEvent
{
    protected LoveDeclarationEvent lde = new LoveDeclarationEvent();

    public static Sprite[] background = new Sprite[7];
    public abstract IEnumerator execute(Season season, Round round, Player player);
    public static async void loadBackground()
    {
        for(int i = 0;i < background.Length; i++)
        {
            background[i] = await Addressables.LoadAssetAsync<Sprite>("background/" + i.ToString("0") + ".jpeg").Task;
        }
        
    }
}
