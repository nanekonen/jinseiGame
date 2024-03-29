using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Lover
{
    public static readonly Lover UNDEFINED = new Lover();

    private string name = "";
    private string fullName = "";

    private Sprite icon;

    private Sprite normal;
    private Sprite privat;

    public Favorability fav = Favorability.UNDEFINED_FAVORABILITY;

    public Lover(string name, string fullName, Favorability fav,Gender g,string path)
    {
        this.name = name;
        this.fullName = fullName;
        this.fav = fav;
        loadImage(g, path);
    }

    
    private async void loadImage(Gender g,string path)
    {
        string p = "image_subject/" + (Gender.WOMAN == g ? "girl" : "boy") + "_" + path + "_";
        Addressables.LoadAssetAsync<Sprite>(p + "normal.png").Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                normal = op.Result;
            }
            else
            {
                Debug.Log("OMG");
            }
        };
        Addressables.LoadAssetAsync<Sprite>(p + "private.png").Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                privat = op.Result;
            }
            else
            {
                Debug.Log("OMG");
            }
        };
        Addressables.LoadAssetAsync<Sprite>("icon_subject/" + (Gender.WOMAN == g ? "girl" : "boy") + "_" + path + ".png").Completed += op =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                icon = op.Result;
            }
            else
            {
                Debug.Log("OMG");
            }
        };
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