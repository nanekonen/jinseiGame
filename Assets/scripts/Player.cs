using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

public class Player : MonoBehaviour
{   
    //hierarchy
    public Transform transform;

    //Status
    public string name;
    public int id;

    public Favorabilities favorabilities;
    public Gender gender = Gender.UNDEFINED_GENDER;
    public Academic academic = Academic.UNDEFINED_ACADEMIC;
    public Appearance appearance = Appearance.UNDEFINED_APPEARANCE;
    public Luck luck = Luck.UNDEFINED_LUCK;
    public LoveInterest loveInterest = LoveInterest.UNDEFINED_LOVE_INTEREST;

    public Lovers lovers = new Lovers();
    public Lover lover = Lover.UNDEFINED;

    public Activity activity = new PartTime();
    //public int activity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void proceed(int number)
    {
        Map.map.positions[id] = (Map.map.positions[id] + number)%Map.map.positions.Count;
        //âÊñ è„Ç…îΩâf

        Map.map.getSquare(Map.map.positions[id]).execution(this);
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

    public void setActivity( int activityID )
    {
        switch( activityID )
        {
            case Activity.BASKETBALLCLUB:
                this.activity = new BasketballClub();
                break;
            case Activity.BRASSBANDCLUB:
                this.activity = new BrassBandClub();
                break;
            case Activity.PARTTIME:
                this.activity = new PartTime();
                break;
            default:
                break;
        }
    }
}
