using UnityEngine;
using UnityEngine.UI;

public class GetToggleValue : MonoBehaviour
{
    public ToggleGroup toggleGroup; // refer to Toggle Group
    private string gender = "";

    // Start is called before the first frame updateValue
    void Start()
    {
        // clear already assigned listener
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.RemoveAllListeners();
        }

        // Toggle Group���̂��ׂĂ�Toggle�ɑ΂��ĐV�����C�x���g���X�i�[��ǉ�
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener((bool value) => OnToggleValueChanged(toggle, value));
        }
    }

    // Toggle�̒l���ύX���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    void OnToggleValueChanged(Toggle toggle, bool value)
    {
        if (value)
        {
            gender = toggle.GetComponentInChildren<Text>().text;

        }
    }

    // ���ׂĂ�Toggle�̏�Ԃ����O�ɕ\�����郁�\�b�h�i�f�o�b�O�p�j
    public void LogToggleStates()
    {
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            Debug.Log("Toggle " + toggle.gameObject.name + " is " + (toggle.isOn ? "ON" : "OFF"));
        }
    }

    public string getGender()
    {
        return this.gender;
    }
}
