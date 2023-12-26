using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputValueManager : MonoBehaviour
{
    public Button submitButton;
    public string targetSceneName;
    public TMP_Text playerNum;

    static object[][] inputValue =
    {
        new object[3],
        new object[3],
        new object[3]
    };
    static int titleInputFormCnt;

    GetField field;
    GetIcon icon;
    GetToggleValue toggle;



    private void Start()
    {
        field = GetComponent<GetField>();
        icon = GetComponent<GetIcon>();
        toggle = GetComponent<GetToggleValue>();
        titleInputFormCnt = 0;
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    private void Update()
    {
        if(field.getPlayerName() == null)
        {

        }
    }

    void OnSubmitButtonClick()
    {
        StartCoroutine("getInputValues");
    }

    IEnumerator getInputValues()
    {
        yield return new WaitForSeconds(1/10);

        inputValue[titleInputFormCnt][0] = field.getPlayerName();
        inputValue[titleInputFormCnt][1] = toggle.getGender();
        inputValue[titleInputFormCnt][2] = icon.getClickedSprite();

        for (int i = 0; i < 3; i++)
        {
            Debug.Log("inputValue[" + titleInputFormCnt + "]" + "[" + i + "]:" + inputValue[titleInputFormCnt][i]);
        }
        titleInputFormCnt++;

        if (titleInputFormCnt == 3)
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            playerNum.text = "Player" + (titleInputFormCnt + 1) + ":";
        }
    }

    void getUnintendedValue()
    {

    }
}
