using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ForcedEvent : MonoBehaviour
{
    public GameMain gamemain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void judgement(int season, int turn);
    public abstract void execution();
}
