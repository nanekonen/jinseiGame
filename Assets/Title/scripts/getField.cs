using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetField : MonoBehaviour
{
    public TMP_InputField tmpInputField;
    public Button submitButton;
    private string playerName;

    // Start is called before the first frame updateValue
    void Start()
    {
        // �{�^���������ꂽ�Ƃ��̏�����o�^
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    // �{�^���������ꂽ�Ƃ��̏���
    void OnSubmitButtonClick()
    {
        this.playerName = tmpInputField.text;

        tmpInputField.text = "";
    }

    public string getPlayerName()
    {
        return this.playerName;
    }
}
