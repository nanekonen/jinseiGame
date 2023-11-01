using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressUI : MonoBehaviour
{
    public static ProgressUI progressUI;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI nowText;

    public TextMeshProUGUI academicText;
    public TextMeshProUGUI apperanceText;
    public TextMeshProUGUI luckText;
    public TextMeshProUGUI affiliationText;

    public TextMeshProUGUI diceText;
    public TextMeshProUGUI spaceText;
    
    
    
    private void Awake()
    {
        progressUI = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeOfTurn(int id)
    {
        Player p = GameMain.gameMain.getPlayer(id);
        string[] s = { "t", "‰Ä", "H", "“~" };
        nameText.text = p.name;nowText.text = s[GameMain.gameMain.nowSeason] + ":" + (GameMain.gameMain.nowRound + 1).ToString("0") + "ƒ^[ƒ“–Ú";
        academicText.text = "Šw—Í " + p.academic.ToString("0");
        apperanceText.text = "—eŽp " + p.apperance.ToString("0");
        luckText.text = "‰^ " + p.luck;
        string[] a = { "ƒoƒXƒP•”", "‘tŠy•”", "ƒoƒCƒg" };
        affiliationText.text = "Š‘® " + a[p.activity];
    }
    
    public void waitDice()
    {
        Debug.Log("waitDice");
        spaceText.enabled = true;
        StartCoroutine(dice());
    }
    IEnumerator dice()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        int d = Random.Range(1, 6);
        diceText.text = d.ToString("0");spaceText.enabled = false;
        GameMain.gameMain.roll = d;
    }
}
