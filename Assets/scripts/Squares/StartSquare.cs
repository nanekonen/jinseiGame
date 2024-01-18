using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSquare : Square
{
    public StartSquare()
    {
        this.id = 4;
    }

    public override void execute(Player player)
    {
        ProgressUI.progressUI.setInstructionSpace("Welcome to Âtƒƒ‚ƒŠ[ƒY");
    }
}
