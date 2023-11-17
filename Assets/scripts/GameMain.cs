using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

public class GameMain : MonoBehaviour
{
    public static GameMain gameMain;

    public Players players = new Players();
    public Player playerObject;
    private Player currentPlayer;

    public const bool english = true;

    private List<ForcedEvent> allForcedEvents = new List<ForcedEvent>();


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
    public void generatePlayer()
    {
        for(int p = 0 ;p < Players.numberOfPlayer; p++)
        {
            new PlayerInformation
            (
                p.ToString("0"),
                Gender.MAN,
                Gender.WOMAN,
                new Academic(p * 50),
                null,
                new Luck(p * 50)
            );

            Player pl = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
            pl.transform.SetParent(transform);
            pl.initialization(p);
            players.add(pl);
        }
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

        generatePlayer();

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
        currentPlayer = players.getPlayer(turn);
        ProgressUI.progressUI.changeOfTurn(currentPlayer, round);
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
        currentPlayer.proceed(roll);
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
