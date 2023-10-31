using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressUI : MonoBehaviour
{
    public static ProgressUI progressUI;

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
