public abstract class Activity
{
    public abstract Results doActivity(Situation situation);
}

public enum ActivityID
{
    BASKETBALL = 0,
    BRASSBAND = 1,
    PARTTIME = 2,
    UNDEFINED = -1
}