using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Search;
using UnityEngine;


public class ForcedEvents : MonoBehaviour
{
    private const string csvDir = "Assets/Resources_moved/CSV/fevents/";

    private List<ForcedEvent> fevents = new List<ForcedEvent>();
    private Season season;
    private Round round;

    public ForcedEvents()
    {

        GWEvent gwEvent = new GWEvent();
        fevents.Add(gwEvent);

    }

    public void add(ForcedEvent fe)
    {
        fevents.Add(fe);
    }

    public IEnumerator execute(Season season, Round round, Player player)
    {
        for( int i = 0; i <  fevents.Count; i++ ) 
        {
            yield return fevents[i].execute(season, round, player);
        }
    }
}