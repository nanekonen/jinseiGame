using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation
{
    private static List<PlayerInformation> list = new List<PlayerInformation>();

    Sprite sprite;

    public string name;
    public int id;

    public Favorabilities favorabilities;
    public Gender gender = Gender.UNDEFINED;
    public Academic academic = Academic.UNDEFINED_ACADEMIC;
    public Appearance appearance = Appearance.UNDEFINED_APPEARANCE;
    public Luck luck = Luck.UNDEFINED_LUCK;
    public Gender loveInterest = Gender.UNDEFINED;

    public Lovers lovers = new Lovers();
    public Lover lover = Lover.UNDEFINED;

    public Activity activity = new PartTime();

    public PlayerInformation()
    {
        list.Add(this);
    }

    public PlayerInformation
    (
        string name,
        Gender gender,
        Gender love_interest,
        Academic academic,
        Sprite sprite,
        Luck luck
    )
    {
        this.name = name;   
        this.gender = gender;
        this.loveInterest = love_interest;
        this.academic = academic;
        this.sprite = sprite;
        this.luck = luck;
        list.Add(this);
    }
    public void updata()
    {
        list.Remove(this);
        list.Insert(id, this);
    }
    
    public static PlayerInformation getInformation(int id)
    {
        return list[id];
    }

    public void reflectResult( Results result )
    {
        for( int i = 0; i < Favorabilities.NUM_OF_PARTNERS; i++ )
        {
            //favorabilities.favorabilities[i].reflectResult( result.academicDev );
        }

        academic.add(result.academicDev);
        appearance.add(result.appearanceDev);
        luck.add(result.luckDev);
    }

    public void setActivity( ActivityID activityID )
    {
        switch( activityID )
        {
            case ActivityID.BASKETBALL:
                this.activity = new BasketballClub();
                break;
            case ActivityID.BRASSBAND:
                this.activity = new BrassBandClub();
                break;
            case ActivityID.PARTTIME:
                this.activity = new PartTime();
                break;
            default:
                break;
        }
    }

}
