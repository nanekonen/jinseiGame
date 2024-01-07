using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using TMPro;

public abstract class Square
{
    public SpriteRenderer sr;
    public TextMeshPro text;

    public string path_image = "Squares/sare";
    public abstract void execute(Player player);

    public async void changeImage()
    {
        var handle = Addressables.LoadAssetAsync<Sprite>(path_image);
        //yield return handle;
        /*
        Sprite s = await Addressables.LoadAssetAsync<Sprite>(path_image).Task;
        if (s == default||s == null) Debug.Log("ÉçÅ[ÉhÇ…é∏îsÇµÇ‹ÇµÇΩ");
        */
        Debug.Log(path_image);
        sr.sprite = await handle.Task;
        Addressables.Release(handle);
    }
}