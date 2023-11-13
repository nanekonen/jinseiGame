using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestSquare : Square
{
    private TextMeshProUGUI text;
    private string sentence;
    private int academic;
    private int apperance;
    private int luck;

    private Player player;
    // Start is called before the first frame update
    public TestSquare(string sentence,int academic,int apperance,int luck)
    {
        this.sentence = sentence;
        this.academic = academic;
    }

    public override void execution(Player player)
    {
        this.player = player;
        text = ProgressUI.progressUI.spaceText;
        text.enabled = true;
        text.text = sentence;
        StartCoroutine(space());
    }
    
    IEnumerator space()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        player.academic += academic;
        player.apperance += apperance;
        player.luck += luck;
        text.enabled = false;
        ProgressUI.progressUI.changeOfTurn(GameMain.gameMain.nowTurn);
        GameMain.gameMain.turn = true;
    }
}
