using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Utilities;
using UnityEngine;

public class Player:MonoBehaviour
{

    public SpriteRenderer sr;

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

    public int activity;
    public int position;

    public float speed;
    public float error;
    private bool move;

    private Vector3 dst;
    private Vector3 dir;
    //public int activity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position += dir * speed;
            if((dst - transform.position).sqrMagnitude < error)
            {
                move = false;
                transform.position = dst;
                Map.map.getSquare(position).execution(this);
            }
        }
    }
    public void initialization(int id)
    {
        PlayerInformation pi = PlayerInformation.getInformation(id);
        name = pi.name;this.id = id;sex = pi.sex;
        love_interest = pi.love_interest;
        academic = pi.academic;
        apperance = pi.apperance;
        sprite = pi.sprite;
        luck = pi.luck;
        position = 0;
        sr.color = new Color(Random.value, Random.value, Random.value, 1f);
        Map.map.addPosition(id);
        arrange();
    }

    private void arrange()
    {
        position = Map.map.getPosition(id);
        int a = Map.map.getArragement(id);
        transform.position = Map.map.getRoute(position);
        transform.position += new Vector3((a % 3 - 1) * 0.3125f, (1 - a / 3) * 0.3125f, 0);
    }

    public void proceed(int number)
    {
        Debug.Log("proceed");
        Map.map.setPosition(id,(Map.map.getPosition(id) + number)%GameMain.gameMain.lengthOfSeason);
        arrange();
        Map.map.getSquare(position).execution(this);
        GameMain.gameMain.turn = true;
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
