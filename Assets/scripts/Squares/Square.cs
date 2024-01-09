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

    private static Dictionary<string, Sprite> dic_Sprite;
    public abstract void execute(Player player);

    public static IEnumerator loadSquares()
    {
        dic_Sprite = new Dictionary<string, Sprite>();
        Dictionary<string, Sprite> dic_Sprite2 = new Dictionary<string, Sprite>();
        string[] ar_key =
        {
            "NormalSquare","ActivitySquare","LoverSquare","springSquare"
        };
        var result =  Addressables.LoadAssetAsync<SpriteAtlas>("squares");
        yield return result;
        foreach(string s in ar_key)
        {
            dic_Sprite.Add(s, result.Result.GetSprite(s));
            Debug.Log(dic_Sprite[s]);
        }
        Addressables.Release(result);
        Debug.Log("FINISH LOAD");
    }
    public void changeImage()
    {
        square_type = this.GetType().FullName;
        Debug.Log(square_type + "  " + dic_Sprite.Count);
        
        sr.sprite = dic_Sprite[square_type];
        Debug.Log(dic_Sprite[square_type]);
    }
}