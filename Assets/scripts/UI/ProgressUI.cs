using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressUI : MonoBehaviour
{
    public static ProgressUI progressUI;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI nowText;

    public TextMeshProUGUI academicText;
    public TextMeshProUGUI apperanceText;
    public TextMeshProUGUI luckText;
    public TextMeshProUGUI affiliationText;

    public TextMeshProUGUI diceText;
    public TextMeshProUGUI spaceText;

    
    private void Awake()
    {
        progressUI = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeOfTurn(in Player player, in Round round)
    {
        //string[] s = { "èt", "âƒ", "èH", "ì~" };
        string[] s = {"spring", "summer", "autumn", "winter"};


        nameText.text = player.pi.name;
        nowText.text = 
            s
            [
                GameMain.gameMain.nowSeason.getID() == Season.UNDEFINED?
                Season.SPRING:
                GameMain.gameMain.nowSeason.getID()
            ] + 
            ":" + 
            round.getRoundInStr() +
            "É^Å[Éìñ⁄";

        academicText.text = "äwóÕ " + player.pi.academic.getValue().ToString("0");
        apperanceText.text = "óeép " + player.pi.appearance.getValue().ToString("0");
        luckText.text = "â^ " + player.pi.luck.getValue().ToString("0");
        affiliationText.text = "èäëÆ " + player.pi.activity.getName();
    }
    
    public void waitDice()
    {
        Debug.Log("waitDice");
        spaceText.enabled = true;
        spaceText.text = "Push your space";
        KeyManager.keyManager.setDownSpace(dice);
    }
    private void dice()
    {
        int d = Random.Range(1, 6);
        diceText.text = d.ToString("0");
        spaceText.enabled = false;
        GameMain.gameMain.processAfterRollingDice(d);
    }
}
