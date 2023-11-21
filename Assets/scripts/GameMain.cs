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

    private Year year = new Year();
    private Season season;


    private Round round = new Round();
    private Turn turn = new Turn(Players.numberOfPlayer);

    private Dice dice = new Dice();

    private ForcedEvents fevents = new ForcedEvents();

    private void Awake()
    {
        Debug.Log("Awake");
        gameMain = this;


        //season = new Season( Season.SPRING );
        season = new Season(Season.UNDEFINED);
    }
    public void generatePlayer()
    {
        for(int p = 0 ;p < Players.numberOfPlayer; p++)
        {
            
            Player pl = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
            pl.transform.SetParent(transform);
            pl.initialize(p);
            pl.pi.setPlayerInfo
            (
                p.ToString("0"),
                Gender.MAN,
                Gender.WOMAN,
                new Academic(p * 50),
                null,
                new Appearance(p * 50), 
                new Luck(p * 50)
            );

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
        for (int s = 0; s < Season.lengthOfSeason; s++)
        {
            tl[s].text.text = s.ToString("0");
        }
        Map.map.changeOfSeason(season);
        turnStart();
    }
    public void turnStart()
    {
        Debug.Log("turnStart");

        currentPlayer = players.getPlayer(turn);
        ProgressUI.progressUI.changeOfTurn(currentPlayer, round, season);
        dice.setCallback(this.diceCallback);
    }
    public void turnEnd()
    {
        Debug.Log("turnEnd");
        fevents.execute(season, round);
        turn.increment();
        if( turn.checkIsFinished() )
        {
            round.increment();
            turn.reset();

            if(round.checkIsFinished())
            {
                changeSeason();
            }
        }
    }

    private void changeSeason()
    {
        Debug.Log("Change season");
        season = season.getNextSeason();

        round.reset();

        Debug.Log(season.getID());
        Map.map.changeOfSeason(season);
        foreach(Player p in players.getAllPlayers())
        {
            p.resetPosition();
        }

    }

    private void diceCallback(int dice)
    {
        Debug.Log("processAfterRollingDice");
        currentPlayer.proceed(dice);
    }

    
}
