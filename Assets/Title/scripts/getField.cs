using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetField : MonoBehaviour
{
    public TMP_InputField tmpInputField; // TextMeshPro��InputField�ւ̎Q��
    public Button submitButton;           // �{�^���ւ̎Q��
    public static string playerName;

    // Start is called before the first frame updateValue
    void Start()
    {
        // �{�^���������ꂽ�Ƃ��̏�����o�^
        submitButton.onClick.AddListener(OnSubmitButtonClick);
    }

    // �{�^���������ꂽ�Ƃ��̏���
    void OnSubmitButtonClick()
    {
        // TextMeshPro��InputField����e�L�X�g���擾
        string playerName = tmpInputField.text;
        Debug.Log("Input Value: " + playerName);
    }
}
