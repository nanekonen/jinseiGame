using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

public class GameMain : MonoBehaviour
{
    public static GameMain gameMain;

    public Players players;

    public Player playerObject;

    private List<ForcedEvent> allForcedEvents = new List<ForcedEvent>();

    public const int lengthOfSeason = 30;

    private Year year = new Year();
    public Season nowSeason { get; private set; }//0:spring,1:summer,2:autumn,3:winter


    private Round round = new Round();
    private Turn turn = new Turn(Players.numberOfPlayer);

    private void Awake()
    {
        Debug.Log("Awake");
        gameMain = this;


        //test!:nowSeason = new Season( Season.SPRING );
        nowSeason = new Season(Season.UNDEFINED);
        players.setOrder();
    }
    void Start()
    {
        Debug.Log("Start");
        startGame();
    }
    private void startGame()
    {
        Debug.Log("startingGame");
        Map.map.generateSquare();

        players.generatePlayer();

        List<RealSquare> tl = Map.map.getRealSquares();
        for (int s = 0; s < 30; s++)
        {
            tl[s].text.text = s.ToString("0");
        }
        Map.map.changeOfSeason(nowSeason);
        turnStart();
    }
    private void turnStart()
    {
        Debug.Log("turnStart");
        if( turn.checkIsFinished() )
        {
            eventOccur();

            round.increment();
            turn.reset();

            if(round.checkIsFinished())
            {
                changeSeason();
            }
        }
        ProgressUI.progressUI.changeOfTurn(player.getPlayer(nowTurn));
        ProgressUI.progressUI.waitDice();
    }

    private void changeSeason()
    {
        Debug.Log("Change season");
        nowSeason = nowSeason.getNextSeason();

        round.reset();

        Debug.Log(nowSeason.getID());
        Map.map.changeOfSeason(nowSeason);
        foreach(Player p in players.getAllPlayers())
        {
            p.resetPosition();
        }

    }

    public void processAfterRollingDice(int roll)
    {
        Debug.Log("processAfterRollingDice");
        allPlayer[getPlayerID(nowTurn)].proceed(roll);
    }

    public void processTransition()
    {
        Debug.Log("processTransition");
        turn.increment();
        turnStart();
    }

    private void eventOccur()
    {
        foreach(ForcedEvent fe in allForcedEvents)
        {
            fe.execution(nowSeason, round);
        }
    }
    
}
