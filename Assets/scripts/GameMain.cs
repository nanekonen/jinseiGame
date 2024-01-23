using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
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


        season = new Season(Season.SPRING);
        //season = new Season(Season.UNDEFINED);
    }

    private Player generatePlayer
    (
        int id,
        string name,
        Gender gender,
        Sprite sprite,
        Activity act
    )
    {
        Player pl = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
        pl.transform.SetParent(transform);
        pl.pi.setPlayerInfo
        (
            name,
            gender,
            sprite,
            act
        );
        pl.initialize(id);

        return pl;

        //players.add(pl);

    }
    public void generatePlayers()
    {
        players.add(generatePlayer(0, (string)InputValueManager.inputValue[0][0], (Gender)InputValueManager.inputValue[0][1], (Sprite)InputValueManager.inputValue[0][2], (Activity)InputValueManager.inputValue[0][3]));
        players.add(generatePlayer(1, (string)InputValueManager.inputValue[1][0], (Gender)InputValueManager.inputValue[1][1], (Sprite)InputValueManager.inputValue[1][2], (Activity)InputValueManager.inputValue[1][3]));
        players.add(generatePlayer(2, (string)InputValueManager.inputValue[2][0], (Gender)InputValueManager.inputValue[2][1], (Sprite)InputValueManager.inputValue[2][2], (Activity)InputValueManager.inputValue[2][3]));
    }
    void Start()
    {
        Debug.Log("Start");
        configureGame();

        StartCoroutine(main());
    }

    IEnumerator main()
    {
        yield return Square.loadSquares();
        ForcedEvent.loadBackground();
        Map.map.changeOfSeason(season);
        while (true)
        {
            currentPlayer = players.getPlayer(turn);
            ProgressUI.progressUI.changeTurn(currentPlayer, round, season);
            ProgressUI.progressUI.setSpaceTextEnabled();
            yield return KeyManager.keyManager.waitForSpace();

            int d = dice.run(round, currentPlayer.position);
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
        tl[0].text.text = "スタート";
        for (int s = 0; s < Season.lengthOfSeason; s++)
        {
            tl[s + 1].text.text = (s + 1).ToString("0");
        }

    }
    private IEnumerator turnEnd()
    {
        turn.increment();
        if (turn.checkIsFinished())
        {
            round.increment();
            foreach(Player p in players.getAllPlayers())
            {
                ProgressUI.progressUI.changeTurn(p, round, season);
                yield return StartCoroutine(fevents.execute(season, round, p));
            }
            
            yield return StartCoroutine(examEvent.execute(season, round, players));
            //yield return fevents.execute(season, round, players.getRandomPlayer());

            turn.reset();

            if (round.checkIsFinished())
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
        foreach (Player p in players.getAllPlayers())
        {
            p.resetPosition();
            p.pi.happiness = new Happiness(p.pi.happiness.update(p.pi));
        }
        ProgressUI.progressUI.updateRnaking(players.getAllPlayers());
    }
}
