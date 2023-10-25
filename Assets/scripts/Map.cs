using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameMain gamemain;
    // List<List<Square>> allsquare = new List<List<Square>>();//argument_0:season,argument_1:number
    //List<List<Sprite>> allsprite = new List<List<Sprite>>();//argument_0:season
    public List<SpriteRenderer> nowSprite = new List<SpriteRenderer>();
    public List<Square> nowSquare = new List<Square>();
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeOfSeason(int season)
    {
        string[] se = { "spring", "summer", "autumn", "winter" };
        Sprite[] sp_ar = Resources.LoadAll<Sprite>("seasons_squares/" + se[season]);
        for(int x = 0;x < nowSprite.Count; x++)
        {
            nowSprite[x].sprite = sp_ar[x];
        }
    }
}
