using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players 
{

    private List<Player> players = new List<Player>();
    public Player playerObject;

    public const int numberOfPlayer = 2;


    public Players()
    {

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

}