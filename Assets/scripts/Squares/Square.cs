using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Square
{
    public SpriteRenderer sr;
    public TextMeshPro text;
    public abstract void execute(in Player player);
    protected void finish()
    {
        GameMain.gameMain.turnStart();
    }
}