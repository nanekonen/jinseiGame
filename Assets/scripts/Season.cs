using UnityEngine;


public class Season
{
    public const int SPRING = 0;
    public const int SUMMER = 1;
    public const int AUTUMN = 2;
    public const int WINTER = 3;

    public const int UNDEFINED = -1;

    private int season = UNDEFINED;

    public Season( int s )
    {
        this.season = s;
    }

    public Season getSeason()
    {
        return new Season( season );
    }

    public int getID()
    {
        return this.season;
    }

    public Season getNextSeason()
    {
        switch( this.season )
        {
            case SPRING:
                return new Season(SUMMER);
                break;
            case SUMMER:
                return new Season(AUTUMN);
                break;
            case AUTUMN:
                return new Season(WINTER);
                break;
            case WINTER:
                return new Season(SPRING);
                break;
            default:
                return new Season(UNDEFINED);
                break;
        }
    }


}