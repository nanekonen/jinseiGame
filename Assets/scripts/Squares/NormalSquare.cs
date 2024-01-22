using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NormalSquare : Square
{

    private string sentence;
    private int academic;
    private int appearance;
    private int luck;

    private Player player;
    // Start is called before the first frame updateValue
    public NormalSquare(string sentence, int academic, int appearance, int luck)
    {
        this.id = 0;
        this.sentence = sentence;
        this.academic = academic;
        this.appearance = appearance;
        this.luck = luck;
    }
    public override IEnumerator execute(Player player)
    {
        Debug.Log("execution");
        this.player = player;
        player.pi.academic.add(academic);
        player.pi.appearance.add(appearance);
        player.pi.luck.add(luck);

        ProgressUI.progressUI.setInstructionSpace
            (
            sentence
            );

        yield return KeyManager.keyManager.waitForSpace();

        ProgressUI.progressUI.setInstructionSpace(
            ((academic != 0) ? "学力が" + Math.Abs(academic) + ((academic > 0) ? "上がった。" : "下がった。") : "") +
            ((appearance != 0) ? "容姿が" + Math.Abs(appearance) + ((appearance > 0) ? "上がった。" : "下がった。") : "") +
            ((luck != 0) ? "学力が" + Math.Abs(luck) + ((luck > 0) ? "上がった。" : "下がった。") : "")
            );

        yield return null;
    }
}
