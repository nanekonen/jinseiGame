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
    private ExamEvent examEvent = new ExamEvent();

    private void Awake()
    {
        Debug.Log("Awake");
        gameMain = this;


        season = new Season( Season.SPRING );
        //season = new Season(Season.UNDEFINED);
    }

    private Player generatePlayer
    (
        int id,
        string name,
        Gender gender,
        Activity act
    )
    {
        Player pl = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
        pl.transform.SetParent(transform);
        pl.initialize(id);
        pl.pi.setPlayerInfo
        (
            name,
            Gender.MAN,
            null,
            act
        );

        return pl;

        //players.add(pl);

    }
    public void generatePlayers()
    {
        players.add(generatePlayer(0, "こうへい",　Gender.MAN, Activity.BASKET));
        players.add(generatePlayer(1, "ゆうや", Gender.WOMAN, Activity.PART_TIME));
        players.add(generatePlayer(2, "しょうへい", Gender.MAN, Activity.BRASS_BAND));

    }
    void Start()
    {
        Debug.Log("Start");
        configureGame();

        StartCoroutine(main());
    }

    IEnumerator main()
    {
        while( true )
        {
            currentPlayer = players.getPlayer(turn);
            ProgressUI.progressUI.changeTurn(currentPlayer, round, season);
            ProgressUI.progressUI.setSpaceTextEnabled();
            yield return KeyManager.keyManager.waitForSpace();

            int d = dice.run(round,currentPlayer.position);
            yield return currentPlayer.proceed(d);

            yield return KeyManager.keyManager.waitForSpace();

            yield return StartCoroutine(turnEnd());

        }
    }

    private void configureGame()
    {
        Debug.Log("startingGame");
        Map.map.generateSquare();

        generatePlayers();

        List<RealSquare> tl = Map.map.getRealSquares();
        for (int s = 0; s < Season.lengthOfSeason; s++)
        {
            tl[s].text.text = s.ToString("0");
        }
        Map.map.changeOfSeason(season);
    }
    private IEnumerator turnEnd()
    {
        turn.increment();
        if( turn.checkIsFinished() )
        {
            round.increment();

            yield return StartCoroutine(fevents.execute(season, round, players.getRandomPlayer()));
            yield return StartCoroutine(examEvent.execute(season, round, players));
            //yield return fevents.execute(season, round, players.getRandomPlayer());

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
            p.pi.happiness = new Happiness(p.pi.happiness.updata(p.pi));
        }
        ProgressUI.progressUI.updataRnaking(players.getAllPlayers());
    }

}
