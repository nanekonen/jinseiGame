using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.AI;

public class Lovers
{
    private List<Lover> lovers = new List<Lover>();

    public Lovers()
    {

    }

    public void add(Lover l)
    {
        lovers.Add(l);
    }

    public Lover getLoverByName(in string name)
    {
        for( int i = 0; i < lovers.Count; i++ )
        {
            if (lovers[i].getName() == name)
            {
                return lovers[i];
            }
        }

        return Lover.UNDEFINED;
    }

    public Lover getHightestLover()
    {
        return Lover.UNDEFINED;
    }
}