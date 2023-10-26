using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
public class Map : MonoBehaviour
{
    public static Map map;

    public List<SpriteRenderer> nowSprite = new List<SpriteRenderer>();
    public List<Square> nowSquare = new List<Square>();

    private void Awake()
    {
        map = this;
    }
    async void Start()
    {
        SpriteAtlas sprite = await Addressables.LoadAssetAsync<SpriteAtlas>("season/spring").Task;
        for(int i = 0;i < sprite.spriteCount; i++)
        {
            nowSprite[i].sprite = sprite.GetSprite(i.ToString("0"));
        }
        Addressables.Release(sprite);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void changeOfSeason(int season)
    {
        string[] se = { "spring", "summer", "autumn", "winter" };
        SpriteAtlas sprite = await Addressables.LoadAssetAsync<SpriteAtlas>("season/" + se[season]).Task;
        for (int i = 0; i < sprite.spriteCount; i++)
        {
            nowSprite[i].sprite = sprite.GetSprite(i.ToString("0"));
        }
        Addressables.Release(sprite);
    }
}
