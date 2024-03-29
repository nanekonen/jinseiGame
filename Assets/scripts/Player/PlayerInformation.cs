using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInformation
{
    //private static List<PlayerInformation> list = new List<PlayerInformation>();

    public Sprite sprite;

    public string name;
    public int id;

    public Gender gender = Gender.UNDEFINED;
    public Academic academic = Academic.UNDEFINED_ACADEMIC;
    public Appearance appearance = Appearance.UNDEFINED_APPEARANCE;
    public Luck luck = Luck.UNDEFINED_LUCK;

    public Lovers lovers;
    public Lover partner = Lover.UNDEFINED;

    public Activity activity = Activity.UNDEFINED;

    public Happiness happiness = Happiness.UNDEFINED_HAPPINESS;
    public Grade grade = Grade.UNDEFINED_GRADE;

    public Color color;
    public PlayerInformation()
    {

    }

    public void setPlayerInfo
    (
        string name,
        Gender gender,
        Sprite sprite,
        Activity activity
    )
    {
        this.name = name;   
        this.gender = gender;
        this.activity = activity;
        this.academic = new Academic();
        this.sprite = sprite;
        this.appearance = new Appearance();
        this.luck = new Luck();
        // this.grade = new Performance(0);

        lovers = new Lovers(gender , activity);
        //list.Add(this);
        //Debug.Log("ADD" + list.Count);
    }

    public void setActivity(Activity a)
    {
        this.activity = a;
        lovers.setActivity(gender, a);
    }

    //public static PlayerInformation getInformation(int id)
    //{
    //    return list[id];
    //}



}
