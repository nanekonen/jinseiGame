using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestSquare : Square
{
    private string sentence;
    private int academic;
    private int appearance;
    private int luck;

    private Player player;
    // Start is called before the first frame update
    public TestSquare(string sentence, int academic, int appearance, int luck)
    {
        this.sentence = sentence;
        this.academic = academic;
        this.appearance = appearance;
        this.luck = luck;
    }
    public override void execute(Player player)
    {
        Debug.Log("execution");
        this.player = player;
        TextMeshProUGUI text;
        (text = ProgressUI.progressUI.spaceText).enabled = true;
        text.text = sentence;
        KeyManager.keyManager.setDownSpace(processAfterSpace);
    }
    private void processAfterSpace()
    {
        player.pi.academic.add(new Deviation(academic));
        player.pi.appearance.add(new Deviation(appearance));
        player.pi.luck.add(new Deviation(luck));
        base.finish();
    }
}
