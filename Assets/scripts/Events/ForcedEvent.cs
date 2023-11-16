using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ForcedEvent : MonoBehaviour
{
    public abstract void execution(Season season, Round round);
}
