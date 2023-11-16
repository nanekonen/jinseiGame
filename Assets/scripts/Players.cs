using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class Players
{

    private List<Player> players = new List<Player>();

    public const int numberOfPlayer = 2;

    private List<int>order = new List<int>();

    private Players() { }

    public Player getNextPlayer()
    {

    }
    
    public void setOrder()
    {
        for(int i = 0;i < Players.numberOfPlayer; i++)
        {
            order.Add(i);
        }
    }

    public void generatePlayer()
    {
        for(int p = 0 ;p < numberOfPlayer; p++)
        {
            new PlayerInformation
            (
                p.ToString("0"),
                Gender.MAN,
                Gender.WOMAN,
                new Academic(p * 50),
                null,
                new Luck(p * 50)
            );

            Player pl = Instantiate(playerObject, Vector3.zero, Quaternion.identity);
            pl.transform.SetParent(transform);
            pl.initialization(p);
            players.Add(pl);
        }
    }
    public Player getPlayer(in int id)
    {
        return players[id];
    }

    public List<Player> getAllPlayers()
    {
        return players;
    }
    
    public int getPlayerOrder(int id)
    {
        return order.IndexOf(id);
    }

    public int getPlayerID(int o)
    {
        return order[o];
    }

    

    public bool setOrder(List<int> o)
    {
        if(o.Count == order.Count)
        {
            foreach(int n in order)
            {
                if (order.Contains(n))
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        order = o;

        return true;
    }
}