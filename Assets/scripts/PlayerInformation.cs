using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation
{
    private static List<PlayerInformation> list = new List<PlayerInformation>();

    public string name;
    public bool sex;//true:man,false:woman
    public bool love_interest;//true:man,false:woman
    public int academic;
    public int apperance;
    public Sprite sprite;
    public int luck;

    public PlayerInformation()
    {
        list.Add(this);
    }
    public PlayerInformation(string name,bool sex,bool love_interest,int academic,Sprite sprite,int luck)
    {
        this.name = name;this.sex = sex;
        this.love_interest = love_interest;
        this.academic = academic;
        this.sprite = sprite;
        this.luck = luck;
        list.Add(this);
    }
    
    public static PlayerInformation getInformation(int id)
    {
        return list[id];
    }

}
