using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players 
{

    private List<Player> players = new List<Player>();
    public Player playerObject;

    public const int numberOfPlayer = 2;

    private List<int>order = new List<int>();

    public Players()
    {

    }

    public void setOrder()
    {
        for(int i = 0;i < Players.numberOfPlayer; i++)
        {
            order.Add(i);
        }
    }

    public Player getPlayer(in Turn turn)
    {
        return players[turn.getTurn()];
    }

    public List<Player> getAllPlayers()
    {
        return players;
    }
    
    
    public void add(Player player)
    {
        players.Add(player);
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