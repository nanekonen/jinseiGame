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

    public int roll;//else:rolled,0:not rolled the dice
    //�T�C�R�����U��ꂽ��i�ރ}�X�ڂ̐���������
    public bool turn;//true:Finished Square,false:In operation

    private List<int>order = new List<int>();

    private void Awake()
    {
        gameMain = this;
        numberOfPlayer = 2;
        nowYear = 0;
        nowSeason = new Season( Season.SPRING );
        nowRound = 0;
        nowTurn = 0;
        roll = 0;
        for(int i = 0;i < numberOfPlayer; i++)
        {
            order.Add(i);
        }
    }
    async void Start()
    {
        Debug.Log("Yeahhh");
        Map.map.generateSquare();
        generatePlayer();
        List<RealSquare> tl = Map.map.getRealSquares();
        for (int s = 0; s < 30; s++)
        {
            tl[s].text.text = s.ToString("0");
        }

        for (int i = 0; i < maxNumberOfSeason; i++)
        {
            nowSeason = nowSeason.getNextSeason();
            Map.map.changeOfSeason(nowSeason);
            for (nowRound = 0; nowRound < maxNumberOfRound; nowRound++)
            {
                for(nowTurn = 0;nowTurn < allPlayer.Count; nowTurn++)
                {
                    Debug.Log("Nice");
                    ProgressUI.progressUI.changeOfTurn(getPlayerID(nowTurn));
                    ProgressUI.progressUI.waitDice();
                    await UniTask.WaitUntil(() => roll != 0);
                    Debug.Log("roll:" + roll);
                    Debug.Log("Bad");
                    allPlayer[getPlayerID(nowTurn)].proceed(roll);
                    roll = 0;
                    await UniTask.WaitUntil(() => turn);
                    turn = false;
                }
                eventOccur();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void generatePlayer()
    {
        for(int p = 0;p < numberOfPlayer; p++)
        {
            new PlayerInformation();
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
