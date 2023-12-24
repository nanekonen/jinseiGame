using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ForcedEvent
{
    protected LoveDeclarationEvent lde = new LoveDeclarationEvent();
    public abstract IEnumerator execute(Season season, Round round, Player player);

}
