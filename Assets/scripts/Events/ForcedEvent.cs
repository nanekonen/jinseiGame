using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;

public abstract class ForcedEvent
{
    protected LoveDeclarationEvent lde = new LoveDeclarationEvent();

    public static Sprite[] background = new Sprite[7];
    public abstract IEnumerator execute(Season season, Round round, Player player);
    public static async void loadBackground()
    {
        Addressables.LoadAssetAsync<SpriteAtlas>("background").Completed += op =>
        {
            if (op.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                op.Result.GetSprites(background);
            }
        };
        if(background == null)
        {
            Debug.Log("OMG");
        }
    }
}
