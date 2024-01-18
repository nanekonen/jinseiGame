using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using TMPro;

public abstract class Square
{
    public SpriteRenderer sr;
    public TextMeshPro text;

    protected int id = -1;

    private static Sprite[]sprites;
    public abstract void execute(Player player);

    public static IEnumerator loadSquares()
    {
        sprites = new Sprite[5];
        Addressables.LoadAssetAsync<SpriteAtlas>("squares").Completed += op =>
        {
            if (op.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                for(int i = 0;i < sprites.Length; i++)
                {
                    sprites[i] = op.Result.GetSprite(i.ToString("0"));
                }
            }
        };
        Debug.Log("FINISH LOAD");
        yield break;
    }
    public void changeImage()
    {
        sr.sprite = sprites[id];
    }
}