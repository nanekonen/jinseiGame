using JetBrains.Annotations;

public class Turn 
{
    private int maxNumberOfTurn = 5;

    private int value; 
    public Turn( in int playerNumber )
    {
        this.maxNumberOfTurn = playerNumber;
        this.value = 0;
    }

    public int getTurn()
    {
        return this.value;
    }

    public bool checkIsFinished()
    {
        if( this.value >= maxNumberOfTurn )
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