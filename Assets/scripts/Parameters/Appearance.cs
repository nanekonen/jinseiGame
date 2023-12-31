using Unity.VisualScripting;

public class Appearance 
{
    public static readonly Appearance UNDEFINED_APPEARANCE = new Appearance();
    public const int DEFAULT = 60;

    public const int MIN = 0;
    public const int MAX = 100;

    public const int UNDEFINED = -1;

    private int value = UNDEFINED;

    public Appearance()
    {
        this.value = DEFAULT;
    }

    //public Appearance( int value )
    //{
    //    int temp_value = value;
    //    if( temp_value > MAX )
    //    {
    //        this.value = MAX;
    //        return;
    //    }
    //    if( temp_value < MIN )
    //    {
    //        this.value = MIN;
    //        return;
    //    }

    //    this.value = value;
    //}



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
    public string getValueInString()
    {
        return this.value.ToString("0");
    }
}