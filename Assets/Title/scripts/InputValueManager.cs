using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputValueManager : MonoBehaviour
{
    public Button nextButton;
    public Button submitButton;
    public string targetSceneName;
    public TMP_Text playerNum;
    public Canvas canvas1;
    public Canvas canvas2;
    public ToggleGroup clubToggleGroup;

    static object[][] inputValue =
    {
        new object[4],
        new object[4],
        new object[4]
    };
    static int titleInputFormCnt;

    GetField field;
    GetIcon icon;
    GetToggleValue genderToggle;
    GetToggleValue affiliationToggle;


    private void Start()
    {
        field = canvas1.GetComponent<GetField>();
        icon = canvas1.GetComponent<GetIcon>();
        genderToggle = canvas1.GetComponent<GetToggleValue>();
        affiliationToggle = canvas2.GetComponent<GetToggleValue>();
        titleInputFormCnt = 0;
        nextButton.onClick.AddListener(OnNextButtonClick);
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    void OnNextButtonClick()
    {
        StartCoroutine("getInputValues1");
    }
    void OnSubmitButtonClick()
    {
        StartCoroutine("getInputValues2");
    }

    IEnumerator getInputValues1()
    {
        yield return new WaitForSeconds(1/10);

        inputValue[titleInputFormCnt][0] = field.getValue();
        inputValue[titleInputFormCnt][1] = genderToggle.getValue();
        inputValue[titleInputFormCnt][2] = icon.getValue();
    }

    IEnumerator getInputValues2()
    {
        yield return new WaitForSeconds(1 / 10);

        inputValue[titleInputFormCnt][3] = affiliationToggle.getValue();
        foreach (Toggle toggle in clubToggleGroup.GetComponentsInChildren<Toggle>())
        {
            if (toggle.GetComponentInChildren<Text>().text == (string)inputValue[titleInputFormCnt][3])
            {
                toggle.interactable = false;
                toggle.isOn = false;
            }
            else
            {
                toggle.isOn = true;
            }
        }
        for (int i = 0; i < 4; i++)
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
            playerNum.text = "Player" + (titleInputFormCnt + 1);
        }
    }
}
