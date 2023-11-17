using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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
                GameMain.gameMain.season.getID() == Season.UNDEFINED?
                Season.SPRING:
                GameMain.gameMain.season.getID()
            ] + 
            ":" + 
            round.getRoundInStr() +
            "th";

        //academicText.text = "äwóÕ " + player.pi.academic.getValueInString();
        //apperanceText.text = "óeép " + player.pi.appearance.getValueInString();
        //luckText.text = "â^ " + player.pi.luck.getValueInString();
        //affiliationText.text = "èäëÆ " + player.pi.activity.getName();
        academicText.text = "academic" + player.pi.academic.getValueInString();
        apperanceText.text = "appearance" + player.pi.appearance.getValueInString();
        luckText.text = "luck" + player.pi.luck.getValueInString();
        affiliationText.text = "activity" + player.pi.activity.getName();
    }
    
    public void setDiceNumber(int dice)
    {
        diceText.text = dice.ToString("0");
        spaceText.enabled = false;
    }

    public void setSpaceTextEnabled()
    {
        spaceText.enabled = true;
        spaceText.text = "Push your space";
    }
}
