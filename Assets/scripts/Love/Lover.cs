using Unity.VisualScripting;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private ActivityID activity = ActivityID.UNDEFINED;

    public Lover(string name, ActivityID activity)
    {
        this.name = name;
        this.activity = activity;
    }

    private Lover()
    {

    }

}