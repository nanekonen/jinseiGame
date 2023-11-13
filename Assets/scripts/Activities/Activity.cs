public abstract class Activity
{
    public const int BASKETBALLCLUB = 0;
    public const int BRASSBANDCLUB = 1;
    public const int PARTTIME = 2;

    public const int UNDEFINED = -1;

    protected int id = UNDEFINED;
    public abstract Results doActivity(Situation situation);

    public int getID()
    {
        return id;
    }
}