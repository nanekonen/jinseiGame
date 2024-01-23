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

    public static PlayerInformation[] pis =
    {
        new PlayerInformation(),
        new PlayerInformation(),
        new PlayerInformation()
    };
    public static bool share = true;
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

        if (share)
        {
            //PlayerInformation pi = new PlayerInformation();
            pis[titleInputFormCnt].name = field.getValue();
            pis[titleInputFormCnt].gender = (genderToggle.getValue().Equals("男性") ? Gender.MAN : Gender.WOMAN);
            pis[titleInputFormCnt].sprite = icon.getValue();
            //pis[titleInputFormCnt] = pi;
        }

        inputValue[titleInputFormCnt][0] = field.getValue();
        inputValue[titleInputFormCnt][1] = genderToggle.getValue();
        inputValue[titleInputFormCnt][2] = icon.getValue();

        canvas1.sortingOrder = 0;
        canvas2.sortingOrder = 10;
    }

    IEnumerator getInputValues2()
    {
        canvas1.sortingOrder = 10;
        canvas2.sortingOrder = 0;

        yield return new WaitForSeconds(1 / 10);

        inputValue[titleInputFormCnt][3] = affiliationToggle.getValue();
        Debug.Log(affiliationToggle.getValue());
        if (share)
        {
            string a = affiliationToggle.getValue();
            pis[titleInputFormCnt].activity = 
                (a == "バスケ部" ? Activity.BASKET : 
                a == "ファミレスバイト" ? Activity.PART_TIME : Activity.BRASS_BAND);
        }
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
            playerNum.text = "プレイヤー" + (titleInputFormCnt + 1);
        }
    }
}
