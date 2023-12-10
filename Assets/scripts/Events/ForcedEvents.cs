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
        using (StreamReader reader = new StreamReader(csvDir + "spring1.csv"))
        {
            ForcedEvent fevent;
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                int timing = 0;
                int.TryParse(values[1], out timing);

                int favorability1 = 0;
                int.TryParse(values[2], out favorability1); 
                
                int favorability2 = 0;
                int.TryParse(values[3], out favorability2);

                fevent = new SpringForcedEvent
                (
                    values[0],
                    timing,
                    favorability1,
                    favorability2
                );
                //fevent.setText(values[0]);
                //foreach (string value in values)
                //Debug.Log(value);
                fevents.Add(fevent);
            }
        }

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