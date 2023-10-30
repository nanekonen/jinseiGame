using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain gameMain;

    private List<Player> allPlayer = new List<Player>();
    private List<ForcedEvent> allForcedEvents = new List<ForcedEvent>();

    public int numberOfRound;

    public int nowYear { set; private get; }
    public int nowSeason { get; private set; }//0:spring,1:summer,2:autumn,3:winter
    public int nowRound { get; private set; }
    public int nowTurn { get; private set; }

    public int roll;//else:rolled,0:not rolled the dice
    //サイコロが振られたら進むマス目の数を代入する

    private List<int>order = new List<int>();

    private void Awake()
    {
        gameMain = this;
        nowYear = 0;
        nowSeason = 0;
        nowRound = 0;
        nowTurn = 0;
        roll = 0;
    }
    void Start()
    {
        season();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void turn()
    {
        ProgressUI.progressUI.changeOfTurn(getPlayerID(nowTurn));
        StartCoroutine(dice());
        allPlayer[getPlayerID(nowTurn)].proceed(roll);
    }

    IEnumerator dice()
    {
        yield return new WaitUntil(() => roll != 0);
    }
    
    private void round()
    {
        for (int t = 0; t < order.Count; t++)
        {
            turn();
            nowTurn++;
        }
        nowTurn = 0;
        eventOccur();
    }

    private void season()
    {
        for(int r = 0;r < numberOfRound;r++)
        {
            round();
            nowRound++;
        }
        nowRound = 0;
        
    }

    private void year()
    {
        for(int s = 0;s < 4; s++)
        {
            season();
            nowSeason = (nowSeason + 1) % 4;
            Map.map.changeOfSeason(nowSeason);
        }
    }

    private void eventOccur()
    {
        foreach(ForcedEvent fe in allForcedEvents)
        {
            fe.judgement(nowSeason, nowRound);
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
