using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.AI;

public class Lovers
{
    private List<Lover> lovers = new List<Lover>();

    // woman
    public Lover mio = new Lover("未央", "松本未央", new Favorability(30));
    public Lover yuna = new Lover("優奈", "中島優奈", new Favorability(30));
    public Lover kasumi = new Lover("香澄", "渡辺香澄", new Favorability(30));
    public Lover miyu = new Lover("みゆ", "富岡みゆ", new Favorability(30));
    public Lover misaki = new Lover("美咲先輩", "齋藤美咲", new Favorability(30));
    public Lover akari = new Lover("明莉", "高橋明莉", new Favorability(30));

    // man
    public Lover ren = new Lover("レン", "大河内レン", new Favorability(30));
    public Lover kenta = new Lover("健太", "高島健太", new Favorability(30));
    public Lover kentaro = new Lover("健太郎", "渡辺健太郎", new Favorability(30));
    public Lover yuto = new Lover("悠斗", "田中悠斗", new Favorability(30));
    public Lover yusuke = new Lover("悠介先輩", "中村悠介", new Favorability(30));
    public Lover daiti = new Lover("大地", "小林大地", new Favorability(30));
    public Lovers(Gender love_interest)
    {
        if( love_interest == Gender.MAN )
        {
            add(ren);
            add(kenta);
            add(kentaro);
            add(yuto);
            add(yusuke);
            add(daiti);
        }
        else
        {
            add(mio);
            add(yuna);
            add(kasumi);
            add(miyu);
            add(misaki);
            add(akari);
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
    public Lover getLoverByFullName(in string fullName)
    {
        for( int i = 0; i < lovers.Count; i++ )
        {
            if (lovers[i].getFullName() == fullName)
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