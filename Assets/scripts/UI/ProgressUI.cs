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
    public RankUI rankUI;


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

    public void changeTurn(in Player player)
    {
        parametersUI.change(player.pi);
        accountUI.change(player.pi);
    }
    public void changeTurn(in Player player, in Round round, in Season season)
    {
        nowUI.change(round,season);
        parametersUI.change(player.pi);
        accountUI.change(player.pi);
        if(player.pi.activity != Activity.UNDEFINED)
        {
            if(player.pi.partner != Lover.UNDEFINED)
            {
                favorabilityUI.turnOff();
            }
            else
            {
                favorabilityUI.turnOn();
                favorabilityUI.setLovers(player.pi.lovers);
            }
        }
        else
        {
            favorabilityUI.turnOff();
        }
    }
    
    public void setDiceNumber(int dice)
    {
        diceUI.rolling(dice);
        setInstructionSpace("");
    }

    public void setSpaceTextEnabled()
    {
        sentenceUI.change("スペースキーを押して、サイコロを振ろう！");
    }

    public void beingLove()
    {
        foreach(Canvas c in sugorokuUI)
        {
            c.enabled = false;
        }
        loveUI.turnOn();
    }

    public void beingSugoroku()
    {
        foreach(Canvas c in sugorokuUI)
        {
            c.enabled = true;
        }
        loveUI.turnOff();
        if (!rankUI.getRank())
        {
            rankUI.turnOff();
        }
    }
    public async void setLove(Sprite background,Sprite subject,string sentence,string name)
    {
        beingLove();
        loveUI.changeBackGround(background);
        loveUI.changeSubject(subject);
        loveUI.changeSentence(sentence);
        loveUI.changeName(name);
    }
    public async void setLove_sentenc_subject(Sprite subject,string sentence,string name)
    {
        beingLove();
        loveUI.changeSubject(subject);
        loveUI.changeSentence(sentence);
        loveUI.changeName(name);
    }
    public void setLove_sentence_name(string s,string n)
    {
        beingLove();
        loveUI.changeSentence(s);
        loveUI.changeName(n);
    }
    public void setLove_sentence(string s)
    {
        beingLove();
        loveUI.changeSentence(s);
    }
    public void setLove_name(string name)
    {
        beingLove();
        loveUI.changeName(name);
    }
    public void updateLoversPercent(Lover l)
    {
        favorabilityUI.setPercent(l);
    }

    public void updateRnaking(List<Player> p_list)
    {
        rankUI.turnOn();
        List<PlayerInformation> list = new List<PlayerInformation>();
        foreach (Player p in p_list)
        {
            list.Add(p.pi);
        }
        rankUI.updateValue(list);
    }
}
