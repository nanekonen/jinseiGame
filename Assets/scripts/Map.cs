using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.AddressableAssets;
using TMPro;
public class Map : MonoBehaviour
{
    public static Map map;

    public GameObject squareObject;
    public Transform mapTransform;

    private List<Square> nowSquare = new List<Square>();
    public List<int> positions = new List<int>();

    private void Awake()
    {
        map = this;
    }
    async void Start()
    {
        List<TextMeshPro> tl = RealSquare.getTextMeshPro();
        generateSquare();
        changeOfSeason(GameMain.gameMain.nowSeason);
        for(int s = 0;s < 30; s++)
        {
            tl[s].text = s.ToString("0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void generateSquare()
    {
        for(int s = 0; s < 10; s++)
        {
            Instantiate(squareObject, new Vector3((float)s - 5, 1f, 0), Quaternion.identity).transform.SetParent(mapTransform);
        }
        for (int s = 0; s < 10; s++)
        {
            Instantiate(squareObject, new Vector3((float)4-s, 0, 0), Quaternion.identity).transform.SetParent(mapTransform);
        }
        for (int s = 0; s < 10; s++)
        {
            Instantiate(squareObject, new Vector3((float)s - 5, -1f, 0), Quaternion.identity).transform.SetParent(mapTransform);
        }
    }

    public async void changeOfSeason(int season)
    {
        List<SpriteRenderer> srl = RealSquare.getSpriteRenderer();
        Debug.Log(srl.Count);
        string[] se = { "spring", "summer", "autumn", "winter" };
        SpriteAtlas sprite = await Addressables.LoadAssetAsync<SpriteAtlas>("season/" + se[season]).Task;
        for (int i = 0; i < sprite.spriteCount; i++)
        {
            srl[i].sprite = sprite.GetSprite(i.ToString("0"));
        }
        Addressables.Release(sprite);

        switch (season)
        {
            case 0:
                nowSquare = new SpringSquares().changeOfSquares(srl,RealSquare.getTextMeshPro());
                break;
            case 1:
                nowSquare = new SummerSquares().changeOfSquares(srl, RealSquare.getTextMeshPro());
                break;
        }
    }

    public Square getSquare(int n)
    {
        return nowSquare[n];
    }
}
