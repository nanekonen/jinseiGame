using Unity.VisualScripting;

public class Deviation
{
    public const int MAX = 100;
    public const int MIN = -100;

    private int value = 0;

    public Deviation(int value)
    {
        int temp_value = value;
        if( temp_value > MAX )
        {
            this.value = MAX;
            return;
        }
        if( temp_value < MIN )
        {
            this.value = MIN;
            return;
        }

        this.value = value;
    }

    public int getValue()
    {
        return this.value;
    }
}

public class FavorabilityDeviation : Deviation
{
    private int id = 0;
    public FavorabilityDeviation( int value, int id ) : base( value )
    {
        this.id = id;
    }
}
