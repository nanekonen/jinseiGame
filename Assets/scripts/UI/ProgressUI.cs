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
            if(player.pi.lover != Lover.UNDEFINED)
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
        sentenceUI.change("Push your space");
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
    }
    public async void setLove(string path_back,string path_sub,string sentence,string name)
    {
        beingLove();
        Sprite s = await Addressables.LoadAssetAsync<Sprite>(path_back).Task;
        loveUI.changeBackGround(s);
        Addressables.Release(s);
        s = await Addressables.LoadAssetAsync<Sprite>(path_sub).Task;
        loveUI.changeBackGround(s);
        Addressables.Release(s);
        loveUI.changeSentence(sentence);
        loveUI.changeName(name);
    }
    public async void setLove_sentenc_subject(string path_sub,string sentence)
    {
        beingLove();
        Sprite s = await Addressables.LoadAssetAsync<Sprite>(path_sub).Task;
        loveUI.changeBackGround(s);
        Addressables.Release(s);
        loveUI.changeSentence(sentence);
    }
    public void setLove_sentence(string s)
    {
        beingLove();
        loveUI.changeSentence(s);
    }
    public void updataLoversPercent(Lover l)
    {
        favorabilityUI.setPercent(l);
    }

    public void updataRnaking(List<Player> p_list)
    {
        List<PlayerInformation> list = new List<PlayerInformation>();
        foreach (Player p in p_list)
        {
            list.Add(p.pi);
        }
        rankUI.updata(list);
    }
}
