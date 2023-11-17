using Unity.VisualScripting;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private ActivityID activity = ActivityID.UNDEFINED;

    private Favorability fav = Favorability.UNDEFINED_FAVORABILITY;

    public Lover(string name, ActivityID activity, Favorability fav)
    {
        this.name = name;
        this.activity = activity;
        this.fav = fav;
    }

    public string getName()
    {
        return this.name;
    }

    private Lover()
    {

    }

}