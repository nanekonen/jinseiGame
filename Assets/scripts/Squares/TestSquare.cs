using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestSquare : Square
{
    private TextMeshProUGUI text;
    private string sentence;
    private int academic;
    private int appearance;
    private int luck;

    private bool waittingSpace = false;
    private Player player;
    // Start is called before the first frame update
    private void Awake()
    {
        base.name = "TestSquare";
        waittingSpace = false;
    }
    public void set(string sentence, int academic, int appearance, int luck)
    {
        this.sentence = sentence;
        this.academic = academic;
        this.appearance = appearance;
        this.luck = luck;
    }
    public override void execution(Player player)
    {
        Debug.Log("execution");
        this.player = player;
        ProgressUI.progressUI.spaceText.enabled = true;
        ProgressUI.progressUI.spaceText.text = sentence;
        waittingSpace = true;
    }
    private void Update()
    {
        if(waittingSpace&& Input.GetKeyDown(KeyCode.Space))
        {
            waittingSpace = false;processAfterSpace();
        }
    }
    private void processAfterSpace()
    {
        player.pi.academic.add(new Deviation(academic));
        player.pi.appearance.add(new Deviation(appearance));
        player.pi.luck.add(new Deviation(luck));
        base.finish();
    }
}
