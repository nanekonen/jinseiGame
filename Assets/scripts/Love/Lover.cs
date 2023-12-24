using Unity.VisualScripting;
using UnityEngine;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private string fullName = "";

    private Sprite icon;

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

    public Sprite getIcon()
    {
        return icon;
    }

    private Lover()
    {

    }

}