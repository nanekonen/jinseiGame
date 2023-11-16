public abstract class Activity
{
    protected ActivityID id;
    protected string name;


    public ActivityID getID()
    {
        return id;
    }

    public string getName()
    {
        return name;
    }
}

public enum ActivityID
{
    BASKETBALL = 0,
    BRASSBAND = 1,
    PARTTIME = 2,
    UNDEFINED = -1
}