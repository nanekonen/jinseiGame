using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ForcedEvent
{
    public abstract IEnumerator execute(Season season, Round round, Player player);

    protected string text = "";
    protected int timing = 0;
    protected int favorability1 = 0;
    protected int favorability2 = 0;



}
