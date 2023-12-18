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

    public List<Canvas> sugorokuUI;

    public AccountUI accountUI;
    public ParametersUI parametersUI;
    public NowUI nowUI;
    public FavorabilityUI favorabilityUI;
    public SentenceUI sentenceUI;
    public DiceUI diceUI;


    public LoveUI loveUI;
    
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
        sentenceUI.change(text);
    }

    public void changeOfTurn(in Player player, in Round round, in Season season)
    {
        nowUI.change(player,round,season);
        parametersUI.change(player.pi);
        accountUI.change(player.pi);
    }
    
    public void setDiceNumber(int dice)
    {
        diceUI.rolling(dice);
    }

    public void setSpaceTextEnabled()
    {
        sentenceUI.change("Push your space");
    }

    private void turnLove()
    {
        foreach(Canvas c in sugorokuUI)
        {
            c.enabled = false;
        }
        loveUI.turnOff();
    }

    private void turnSugoroku()
    {
        foreach(Canvas c in sugorokuUI)
        {
            c.enabled = true;
        }
        loveUI.turnOn();
    }
    public async void setBackground(string path)
    {
        turnLove();
        Sprite s = await Addressables.LoadAssetAsync<Sprite>(path).Task;
        loveUI.changeBackGround(s);
        Addressables.Release(s);
    }
}
