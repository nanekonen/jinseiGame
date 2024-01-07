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

    public string square_type = "NormalSquare";

    private static Dictionary<string, Sprite> dic_Sprite = new Dictionary<string, Sprite>();
    public abstract void execute(Player player);

    public static IEnumerator loadSquares()
    {
        string[] ar_key =
        {
            "NormalSquare","ActivitySquare","loveSquare","springSquare"
        };
        var result =  Addressables.LoadAssetAsync<SpriteAtlas>("squares");
        yield return result;
        foreach(string s in ar_key)
        {
            dic_Sprite.Add(s, result.Result.GetSprite(s));
        }
        Addressables.Release(result);
        Debug.Log("FINISH LOAD");
    }
    public void changeImage()
    {
        square_type = this.GetType().FullName;
        Debug.Log(square_type + "  " + dic_Sprite.Count);
        sr.sprite = dic_Sprite[square_type];
    }
}