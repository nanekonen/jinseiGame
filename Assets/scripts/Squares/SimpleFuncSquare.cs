using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleFuncSquare : Square
{
    private string sentence;
    public delegate void ChangeInAbility(int d);
    private ChangeInAbility func;
    private int d;

    private Player player;
    // Start is called before the first frame update
    public SimpleFuncSquare(string sentence, ChangeInAbility func, int d)
    {
        this.sentence = sentence;
        this.func = func;
        this.d = d;
    }
    public SimpleFuncSquare(string sentence, ChangeInAbility func1, ChangeInAbility func2, int d)
    {
        this.sentence = sentence;
        this.func = func1;
        this.func += func2;
        this.d = d;
    }
    public SimpleFuncSquare(string sentence, ChangeInAbility func1, ChangeInAbility func2, ChangeInAbility func3, int d)
    {
        this.sentence = sentence;
        this.func = func1;
        this.func += func2;
        this.func += func3;
        this.d = d;
    }

    public override void execute(Player player)
    {
        this.player = player;
        ProgressUI.progressUI.setInstructionSpace(sentence);
        //text = ProgressUI.progressUI.spaceText;
        //text.enabled = true;
        //text.text = sentence;
        //KeyManager.keyManager.setSpaceCallback(space);
    }

    public void space()
    {
        func(this.d);
        text.enabled = false;
        //base.finish();
    }
}
