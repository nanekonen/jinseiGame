using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private string fullName = "";

    private Sprite icon;

    private Sprite normal;
    private Sprite privat;

    public Favorability fav = Favorability.UNDEFINED_FAVORABILITY;

    public Lover(string name, string fullName, Favorability fav)
    {
        this.name = name;
        this.fullName = fullName;
        this.fav = fav;
        //loadImage(g, a);
    }

    /*
    private async void loadImage(Gender g,Activity a)
    {
        string p = "image_subject/" + (g == Gender.MAN ? "boy" : "girl") + "_" + a.ToString("0");
        Sprite s;
        normal = s = await Addressables.LoadAssetAsync<Sprite>(p + "_normal.jpg").Task;
        Addressables.Release(s);
        privat = s = await Addressables.LoadAssetAsync<Sprite>(p + "_private.jpg").Task;
        Addressables.Release(s);
    }
    */

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

    public Sprite getNormal()
    {
        return normal;
    }

    public Sprite getPrivate()
    {
        return privat;
    }

    private Lover()
    {

    }
}