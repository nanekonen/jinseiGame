using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugorokuUI : MonoBehaviour
{
    public List<PartsUI> sugoroku_parts;
    
    public void turnOn()
    {
        foreach(PartsUI p in sugoroku_parts)
        {
            p.turnOn();
        }
    }

    public void turnOff()
    {
        foreach(PartsUI p in sugoroku_parts)
        {
            p.turnOff();
        }
    }
}
