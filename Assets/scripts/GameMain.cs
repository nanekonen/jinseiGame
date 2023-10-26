using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain gamemain;

    public List<Player> allPlayer = new List<Player>();
    public List<ForcedEvent> allForcedEvents = new List<ForcedEvent>();
    public int nowSeason = 0;//0:spring,1:summer,2:autumn,3:winter

    private void Awake()
    {
        gamemain = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
