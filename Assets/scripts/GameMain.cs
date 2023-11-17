﻿using System.Linq;
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
    public Season season { get; private set; }//0:spring,1:summer,2:autumn,3:winter


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
                new Appearance(p * 50), 
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

        turn.increment();
        fevents.execute(season, round);

        if( turn.checkIsFinished() )
        {

            round.increment();
            turn.reset();

            if(round.checkIsFinished())
            {
                changeSeason();
            }
        }
        currentPlayer = players.getPlayer(turn);
        ProgressUI.progressUI.changeOfTurn(currentPlayer, round);
        dice.setCallback(this.diceCallback);
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
