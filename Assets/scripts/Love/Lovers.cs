using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.AI;

public class Lovers
{
    private List<Lover> lovers = new List<Lover>();

    public Lovers(Lover l1, Lover l2)
    {
        lovers.Add(l1);
        lovers.Add(l2);
    }

    public Lovers()
    {

    }

    public void add(Lover l1, Lover l2)
    {
        lovers.Add(l1);
        lovers.Add(l2);
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
}