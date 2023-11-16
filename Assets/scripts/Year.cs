public class Year 
{
    private const int maxYear = 1;

    private int value; 
    public Year()
    {
        this.value = 0; 
    }

    public int getYear()
    {
        return this.value;
    }

    public bool checkIsFinished()
    {
        if( this.value == maxYear - 1 )
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

    public void increment()
    {
        this.value++;
    }

    public void reset()
    {
        this.value = 0;
    }


}