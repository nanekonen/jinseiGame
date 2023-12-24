public class Round
{
    private const int maxNumberOfRound = 5;

    private int value; 
    public Round()
    {
        this.value = 0; 
    }

    public int getRound()
    {
        return this.value;
    }

    public bool checkIsFinished()
    {
        if( this.value >= maxNumberOfRound  )
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

    public string getRoundInStr()
    {
        return (this.value + 1).ToString("0");
    }

}