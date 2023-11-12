public class BasketballClub : Activity
{

    public BasketballClub()
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