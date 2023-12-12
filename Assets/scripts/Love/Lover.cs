using Unity.VisualScripting;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private string fullName = "";

    public Favorability fav = Favorability.UNDEFINED_FAVORABILITY;

    public Lover(string name, string fullName, Favorability fav)
    {
        this.name = name;
        this.fullName = fullName;
        this.fav = fav;
    }

    public string getName()
    {
        return this.name;
    }
    public string getFullName()
    {
        return this.fullName;
    }

    private Lover()
    {

    }

}