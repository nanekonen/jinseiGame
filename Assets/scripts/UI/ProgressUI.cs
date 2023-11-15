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

    private bool waittingDice = false;
    
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
        if (waittingDice&&Input.GetKeyDown(KeyCode.Space))
        {
            waittingDice = false;dice();
        }
    }

    public void changeOfTurn(int id)
    {
        Player p = GameMain.gameMain.getPlayer(id);
        string[] s = { "�t", "��", "�H", "�~" };
        nameText.text = p.name;nowText.text = s[GameMain.gameMain.nowSeason.getID()] + ":" + (GameMain.gameMain.nowRound + 1).ToString("0") + "�^�[����";
        academicText.text = "�w�� " + p.pi.academic.getValue().ToString("0");
        apperanceText.text = "�e�p " + p.pi.appearance.getValue().ToString("0");
        luckText.text = "�^ " + p.pi.luck.getValue().ToString("0");
        affiliationText.text = "���� " + p.pi.activity.getName();
    }
    
    public void waitDice()
    {
        Debug.Log("waitDice");
        spaceText.enabled = true;
        spaceText.text = "Push your space";
        waittingDice = true;
    }
    private void dice()
    {
        int d = Random.Range(1, 6);
        diceText.text = d.ToString("0");
        spaceText.enabled = false;
        GameMain.gameMain.processAfterRollingDice(d);
    }
}
