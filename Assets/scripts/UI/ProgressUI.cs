using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
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

    public Image background;

    
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

    public void setInstructionSpace(in string text)
    {
        spaceText.enabled = true;
        spaceText.text = text;
    }

    public void changeOfTurn(in Player player, in Round round, in Season season)
    {
        //string[] s = { "èt", "âƒ", "èH", "ì~" };
        string[] s = {"spring", "summer", "autumn", "winter"};


        nameText.text = player.pi.name;
        nowText.text = 
            s
            [
                season.getID() == Season.UNDEFINED?
                Season.SPRING:
                season.getID()
            ] + 
            ":" + 
            round.getRoundInStr() +
            "th";

        //academicText.text = "äwóÕ " + player.pi.academic.getValueInString();
        //apperanceText.text = "óeép " + player.pi.appearance.getValueInString();
        //luckText.text = "â^ " + player.pi.luck.getValueInString();
        //affiliationText.text = "èäëÆ " + player.pi.activity.getName();
        academicText.text = player.pi.academic.getValueInString();
        apperanceText.text = player.pi.appearance.getValueInString();
        luckText.text = player.pi.luck.getValueInString();
        //affiliationText.text = "activity" + player.pi.activity.getName();
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

    public void setText(string text)
    {
        spaceText.enabled = true;
        spaceText.text = text;
    }

    public void disableText()
    {
        spaceText.enabled = false;
    }

    public async void setBackground(string path)
    {
        background.enabled = true;
        Sprite s = await Addressables.LoadAssetAsync<Sprite>(path).Task;
        
        Debug.Log("Yes");
        background.sprite = s;
        Addressables.Release(s);
    }

    public void disableeBackground()
    {
        background.enabled = false;
    }
}
