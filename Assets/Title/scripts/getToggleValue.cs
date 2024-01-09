using UnityEngine;
using UnityEngine.UI;

public class GetToggleValue : MonoBehaviour
{
    public ToggleGroup toggleGroup; // refer to Toggle Group
    private string val = "";

    // Start is called before the first frame update
    void Start()
    {
        // clear already assigned listener
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.RemoveAllListeners();
        }
        
        // Toggle Group内のすべてのToggleに対して新しいイベントリスナーを追加
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener((bool value) => OnToggleValueChanged(toggle, value));
            if (toggle.isOn)
            {
                val = toggle.GetComponentInChildren<Text>().text;
            }
        }
    }

    // Toggleの値が変更されたときに呼ばれるメソッド
    void OnToggleValueChanged(Toggle toggle, bool value)
    {
        if (value)
        {
            val = toggle.GetComponentInChildren<Text>().text;
        }
    }

    // すべてのToggleの状態をログに表示するメソッド（デバッグ用）
    public void LogToggleStates()
    {
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            Debug.Log("Toggle " + toggle.gameObject.name + " is " + (toggle.isOn ? "ON" : "OFF"));
        }
    }

    public string getValue()
    {
        return this.val;
    }
}
