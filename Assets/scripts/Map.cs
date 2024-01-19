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

    private List<RealSquare> nowSquares = new List<RealSquare>();
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
        route.Add(new Vector3(0, 2.25f, 0));
        for(int s = 0;s < 10; s++)
        {
            route.Add(new Vector3((float)s - 5f + 0.5f, 1f,0));
        }
        for (int s = 0; s < 10; s++)
        {
            route.Add(new Vector3((float)4 - s + 0.5f, 0, 0)) ;
        }
        for (int s = 0; s < 10; s++)
        {
            route.Add(new Vector3((float)s - 5f + 0.5f, -1f, 0));
        }
        foreach (Vector3 v in route)
        {
            RealSquare rs = Instantiate(squareObject, v, Quaternion.identity);
            rs.transform.SetParent(transform);
            nowSquares.Add(rs);
        }
    }

    public async void changeOfSeason(Season season)
    {
        List<Square> squares = new List<Square>();
        switch (season.getID())
        {
            case Season.SPRING:
                squares = new SpringSquares().changeOfSquares();
                break;
            case Season.SUMMER:
                squares = new SummerSquares().changeOfSquares();
                break;
            case Season.UNDEFINED:
                squares = new TestSeason().changeOfSquares();
                break;
            default:
                break;
        }
        nowSquares[0].change(new StartSquare());
        for(int i0 = 0;i0 < squares.Count&&i0 < nowSquares.Count; i0++)
        {
            nowSquares[i0 + 1].change(squares[i0]);
        }
    }

    public List<RealSquare> getRealSquares()
    {
        return nowSquares;
    }

    public Square getSquare(int n)
    {
        return nowSquares[n % Season.lengthOfSeason].square;
    }
    public void addPosition(int id)
    { 
        for(int i = 0;arragement.Count < 31; i++)
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
        arragement[positions[id]].Remove(id);
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
