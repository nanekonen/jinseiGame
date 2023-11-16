using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

public class GameMain : MonoBehaviour
{
    public static GameMain gameMain;

    public Player playerObject;

    private List<Player> allPlayer = new List<Player>();
    private List<ForcedEvent> allForcedEvents = new List<ForcedEvent>();

    public int numberOfPlayer = 2;
    public int lengthOfSeason = 30;

    public int nowYear { set; private get; }
    public Season nowSeason { get; private set; }//0:spring,1:summer,2:autumn,3:winter
    private const int maxNumberOfYear = 1;
    private const int maxNumberOfSeason = 2;
    private const int maxNumberOfRound = 5;
    
    
    public int nowRound { get; private set; }
    public int nowTurn { get; private set; }

    private List<int>order = new List<int>();


    private void Awake()
    {
        Debug.Log("Awake");
        gameMain = this;
        nowYear = 0;
        nowSeason = new Season( Season.SPRING );
        nowRound = 0;
        nowTurn = 0;
        numberOfPlayer = 2;
        lengthOfSeason = 30;
        for(int i = 0;i < numberOfPlayer; i++)
        {
            order.Add(i);
        }
        startingGame();
        
    }
    void Start()
    {
        Debug.Log("Start");
    }
    private void startingGame()
    {
        Debug.Log("startingGame");
        Map.map.generateSquare();
        generatePlayer();
        List<RealSquare> tl = Map.map.getRealSquares();
        for (int s = 0; s < 30; s++)
        {
            tl[s].text.text = s.ToString("0");
        }
        Map.map.changeOfSeason(new Season(Season.UNDEFINED));//debug
        turnStart();
    }
    private void turnStart()
    {
        Debug.Log("turnStart");
        if(nowTurn == allPlayer.Count())
        {
            eventOccur();
            nowRound++;
            nowTurn = 0;
            if(nowRound == maxNumberOfRound - 1)
            {
                nowSeason = nowSeason.getNextSeason();
                nowRound = 0;
                Map.map.changeOfSeason(nowSeason);
            }
        }
        ProgressUI.progressUI.changeOfTurn(getPlayerID(nowTurn));
        ProgressUI.progressUI.waitDice();
    }

    public void processAfterRollingDice(int roll)
    {
        Debug.Log("processAfterRollingDice");
        allPlayer[getPlayerID(nowTurn)].proceed(roll);
    }

    public void processTransition()
    {
        Debug.Log("processTransition");
        nowTurn++;
        turnStart();
    }
    private void generatePlayer()
    {
        for(int p = 0;p < numberOfPlayer; p++)
        {
            PlayerInformation pi = new PlayerInformation();
            pi.name = "Player" + p;
            pi.updata();
            Player pl = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
            pl.transform.SetParent(transform);
            pl.initialization(p);
            allPlayer.Add(pl);
        }
    }

    private void eventOccur()
    {
        foreach(ForcedEvent fe in allForcedEvents)
        {
            fe.execution(nowSeason, nowRound);
        }
    }
    
    public Player getPlayer(int id)
    {
        return allPlayer[id];
    }
    

    public int getPlayerOrder(int id)
    {
        return order.IndexOf(id);
    }

    public int getPlayerID(int o)
    {
        return order[o];
    }

    public bool setOrder(List<int> o)
    {
        if(o.Count == order.Count)
        {
            foreach(int n in order)
            {
                if (order.Contains(n))
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        order = o;

        return true;
    }
}
