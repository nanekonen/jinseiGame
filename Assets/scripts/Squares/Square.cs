using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public abstract class Square
{
    public SpriteRenderer sr;
    public TextMeshPro text;

    protected int id = -1;

    private static Sprite[]sprites;
    public abstract IEnumerator execute(Player player);

    public static IEnumerator loadSquares()
    {
        sprites = new Sprite[5];
        for(int i = 0;i < sprites.Length; i++)
        {
            AsyncOperationHandle<Sprite> ie = Addressables.LoadAssetAsync<Sprite>("square/" + i.ToString("0") + ".png");
            yield return ie;
            if (ie.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                sprites[i] = ie.Result;
            }
        }
        
        Debug.Log("FINISH LOAD");
        yield break;
    }
    public void changeImage()
    {
        sr.sprite = sprites[id];
    }
}