using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class Favorability 
{
    public static readonly Favorability UNDEFINED_FAVORABILITY = new Favorability();
    
    public const int MIN = 0;
    public const int MAX = 100;

    public const int UNDEFINED = -1;

    private int value = UNDEFINED;

    public Favorability( int value )
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

    private Favorability()
    {
        this.value = UNDEFINED;
    }
    

    public void add( int value )
    {
        int temp_value = this.value + value; 

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

        this.value = temp_value;
    }

    public void sub( int value )
    {
        int temp_value = this.value - value; 

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

        this.value = temp_value;
    }

    public int getValue()
    {
        return this.value;
    }
}