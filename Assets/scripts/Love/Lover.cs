using Unity.VisualScripting;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";

    public Favorability fav = Favorability.UNDEFINED_FAVORABILITY;

    public Lover(string name, Favorability fav)
    {
        this.name = name;
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