public class PartTime : Activity
{
    public PartTime()
    {

    }
    public override Results doActivity(Situation situation)
    {
        return new Results
        (
            new Deviation(0), 
            new Deviation(0), 
            new Deviation(0), 
            new FavorabilityDeviation(0,0)
        ); 
    }
}