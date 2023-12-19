using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartsUI : MonoBehaviour
{
    public Canvas canvas;
    public void turnOn()
    {
        canvas.enabled = true;
    }
    public void turnOff()
    {
        canvas.enabled = false;
    }
}
