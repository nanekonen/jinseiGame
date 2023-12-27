using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetField : MonoBehaviour
{
    public TMP_InputField tmpInputField; // TextMeshProのInputFieldへの参照
    public Button submitButton;           // ボタンへの参照
    public static string playerName;

    // Start is called before the first frame updateValue
    void Start()
    {
        // ボタンが押されたときの処理を登録
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    // ボタンが押されたときの処理
    void OnSubmitButtonClick()
    {
        // TextMeshProのInputFieldからテキストを取得
        string playerName = tmpInputField.text;
        Debug.Log("Input Value: " + playerName);
    }
}
