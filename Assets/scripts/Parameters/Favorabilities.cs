using System.Collections.Generic;
using Unity.VisualScripting;

public class Favorabilities
{
    public const int NUM_OF_PARTNERS = 2;
    public List<Favorability> favorabilities = new List<Favorability>();

    public Favorabilities()
    {
    }

    public void add( Favorability favorability )
    {
        favorabilities.Add( favorability );
    }


    public Favorability getHighestFavorability()
    {
        int highestIndex = 0;
        Favorability highest = favorabilities[highestIndex];
        for( int i = 0; i <  favorabilities.Count; i++ ) 
        {
            if(favorabilities[i].getValue() > highest.getValue() ) 
            {
                highestIndex = i;
                highest = favorabilities[i];
            }
        }

        return highest;
    }
}