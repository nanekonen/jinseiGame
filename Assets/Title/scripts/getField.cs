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
        // ボタンが押されたときの処理を登録
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    // ボタンが押されたときの処理
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
