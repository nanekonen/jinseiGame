using UnityEngine;
using UnityEngine.UI;

public class getToggleValue : MonoBehaviour
{
    public ToggleGroup toggleGroup; // Toggle Group�ւ̎Q��
    public static string gender = "";
    public static string targetGender = "";

    // Start is called before the first frame update
    void Start()
    {
        // ���łɓo�^����Ă��郊�X�i�[���N���A
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
            // Toggle���I���ɂȂ����ꍇ�̏���
            Debug.Log("Toggle " + toggle.gameObject.name + " is ON");
            if (toggle.gameObject.name.Contains("target"))
            {
                targetGender = toggle.GetComponentInChildren<Text>().text;
                Debug.Log("targetGender: " + targetGender);
            }
            else
            {
                gender = toggle.GetComponentInChildren<Text>().text;
                Debug.Log("gender: " + gender);
            }
                ;
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
}
