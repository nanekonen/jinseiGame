using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Square
{
    public SpriteRenderer sr;
    public TextMeshPro text;
    public abstract void execution(Player player);

}