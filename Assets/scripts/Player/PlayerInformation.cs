using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInformation
{
    //private static List<PlayerInformation> list = new List<PlayerInformation>();

    Sprite sprite;

    public string name;
    public int id;

    public Gender gender = Gender.UNDEFINED;
    public Academic academic = Academic.UNDEFINED_ACADEMIC;
    public Appearance appearance = Appearance.UNDEFINED_APPEARANCE;
    public Luck luck = Luck.UNDEFINED_LUCK;
    public Gender loveInterest = Gender.UNDEFINED;

    public Lovers lovers = new Lovers();
    public Lover lover = Lover.UNDEFINED;


    public PlayerInformation()
    {

    }

    public void setPlayerInfo
    (
        string name,
        Gender gender,
        Gender love_interest,
        Academic academic,
        Sprite sprite,
        Appearance appearance,
        Luck luck
    )
    {
        this.name = name;   
        this.gender = gender;
        this.loveInterest = love_interest;
        this.academic = academic;
        this.sprite = sprite;
        this.appearance = appearance;
        this.luck = luck;
        //list.Add(this);
        //Debug.Log("ADD" + list.Count);
    }


    //public static PlayerInformation getInformation(int id)
    //{
    //    return list[id];
    //}



}