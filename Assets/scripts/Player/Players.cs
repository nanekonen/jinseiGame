using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players 
{

    private List<Player> players = new List<Player>();
    public Player playerObject;

    public const int numberOfPlayer = 3;

    private System.Random rand = new System.Random();

    public Players()
    {

    }

    public Player getRandomPlayer()
    {
        int index = rand.Next(0, numberOfPlayer);
        return players[index];
    }

    public Player getPlayer(int index)
    {
        return players[index];
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