using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.AI;

public class Lovers
{
    private List<Lover> lovers = new List<Lover>();

    // woman
    public Lover megumi = new Lover("めぐみ", new Favorability(30));
    public Lover momoe = new Lover("ももえ", new Favorability(30));
    public Lover kanade = new Lover("かなで", new Favorability(30));
    public Lover shizue = new Lover("しずえ", new Favorability(30));
    public Lover meary = new Lover("メアリー", new Favorability(30));
    public Lover kaho = new Lover("かほ", new Favorability(30));

    // man
    public Lover hiroki = new Lover("ひろき", new Favorability(30));
    public Lover taichi = new Lover("たいち", new Favorability(30));
    public Lover kouhei = new Lover("こうへい", new Favorability(30));
    public Lover taihei = new Lover("たいへい", new Favorability(30));
    public Lover kaisei = new Lover("かいせい", new Favorability(30));
    public Lover jaian = new Lover("ジャイアン", new Favorability(30));

    public Lovers(Gender myGender)
    {
        if( myGender == Gender.MAN )
        {
            add(megumi);
            add(momoe);
        }
        else
        {
            add(hiroki);
            add(taichi);
        }
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

    public List<string> getAllLoverName()
    {
        List<string> names = new List<string>();

        for( int i = 0; i < lovers.Count; i++ )
        {
            names.Add(lovers[i].getName() );
        }

        return names;
    }


}