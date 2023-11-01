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

    public RealSquare squareObject;

    private List<Vector3> route = new List<Vector3>();

    private List<RealSquare> realSquares = new List<RealSquare>();
    private List<Square> nowSquare = new List<Square>();
    private List<int> positions = new List<int>();
    private List<List<int>> arragement = new List<List<int>>();

    private void Awake()
    {
        map = this;
    }
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void generateSquare()
    {
        for(int s = 0;s < 10; s++)
        {
            route.Add(new Vector3((float)s - 5f, 1f,0));
        }
        for (int s = 0; s < 10; s++)
        {
            route.Add(new Vector3((float)4 - s, 0, 0));
        }
        for (int s = 0; s < 10; s++)
        {
            route.Add(new Vector3((float)s - 5f, -1f, 0));
        }
        foreach (Vector3 v in route)
        {
            RealSquare rs = Instantiate(squareObject, v, Quaternion.identity);
            rs.transform.SetParent(transform);
            realSquares.Add(rs);
        }
    }

    public async void changeOfSeason(int season)
    {
        string[] se = { "spring", "summer", "autumn", "winter" };
        SpriteAtlas sprite = await Addressables.LoadAssetAsync<SpriteAtlas>("season/" + se[season]).Task;
        for (int i = 0; i < sprite.spriteCount; i++)
        {
            realSquares[i].sr.sprite = sprite.GetSprite(i.ToString("0"));
        }
        Addressables.Release(sprite);
        season = -1;//DEBUG
        switch (season)
        {
            case 0:
                nowSquare = new SpringSquares().changeOfSquares(realSquares);
                break;
            case 1:
                nowSquare = new SummerSquares().changeOfSquares(realSquares);
                break;
            case -1:
                nowSquare = new TestSeason().changeOfSquares(realSquares);
                break;
        }
    }

    public List<RealSquare> getRealSquares()
    {
        return realSquares;
    }

    public Square getSquare(int n)
    {
        return nowSquare[n];
    }
    public void addPosition(int id)
    {
        for(int i = 0;arragement.Count < 30; i++)
        {
            arragement.Add(new List<int>());
        }
        if(id == positions.Count)
        {
            positions.Add(0);
            
            arragement[0].Add(id);
        }
    }
    public int getPosition(int id)
    {
        return positions[id];
    }
    public int getArragement(int id)
    {
        return arragement[positions[id]].IndexOf(id);
    }
    public void setPosition(int id,int n)
    {
        arragement[positions[id]].Remove(arragement[positions[id]].IndexOf(id));
        positions[id] = n;
        arragement[n].Add(id);
    }
    public int getSquarePeople(int n)
    {
        return positions.Count(item => item == n);
    }
    public Vector3 getRoute(int n)
    {
        return route[n];
    }
}
