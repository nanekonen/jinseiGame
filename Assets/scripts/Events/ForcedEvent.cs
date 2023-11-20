using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ForcedEvent
{
    public delegate void Finish();
    protected Finish fin;
    public abstract void execute(Season season, Round round);

    public void added(Finish f)
    {
        fin = f;
    }
    protected void finish()
    {
        fin();
    }
}
