using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameMain gamemain;
    List<List<Square>> allsquare = new List<List<Square>>();//argument_0:season,argument_1:number
    List<List<Sprite>> allsprite = new List<List<Sprite>>();//argument_0:season
    public List<Sprite> nowsprite = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeOfSeason()
    {
        foreach(Sprite s in allsprite[(GameMain.nowseason + 1)%4])
    }
}
