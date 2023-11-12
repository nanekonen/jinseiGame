using Unity.VisualScripting;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private int activity = Activity.UNDEFINED;

    public Lover(string name, int activity)
    {
        this.name = name;
        this.activity = activity;
    }

    private Lover()
    {

    }

}