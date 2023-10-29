using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain gamemain;

    public Dictionary<string, Player> allPlayer = new Dictionary<string, Player>();
    public List<ForcedEvent> allForcedEvents = new List<ForcedEvent>();

    public int numberOfRound;

    public int nowSeason { get; private set; }//0:spring,1:summer,2:autumn,3:winter
    public int nowRound { get; private set; }
    public int nowTurn { get; private set; }

    public int roll;//else:rolled,0:not rolled the dice
    //サイコロが振られたら進むマス目の数を代入する

    private List<string>order = new List<string>();

    private void Awake()
    {
        gamemain = this;
        nowSeason = 0;
        nowRound = 0;
        nowTurn = 0;
        roll = 0;
    }
    void Start()
    {
        season();
        season();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void turn()
    {
        ProgressUI.progressUI.changeOfTurn(getPlayerName(nowTurn));
        StartCoroutine(dice());
        allPlayer[getPlayerName(nowTurn)].proceed(roll);
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
        nowSeason = (nowSeason + 1) % 4;
        Map.map.changeOfSeason(nowSeason);
    }

    private void eventOccur()
    {
        foreach(ForcedEvent fe in allForcedEvents)
        {
            fe.judgement(nowSeason, nowRound);
        }
    }

    public string getPlayerName(int number)
    {
        return order[number];
    }

    public int getPlayerNumber(string name)
    {
        return order.IndexOf(name);
    }

    public bool setOrder(List<string> o)
    {
        if(o.Count == order.Count)
        {
            foreach(string n in order)
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
