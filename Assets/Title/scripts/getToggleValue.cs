using UnityEngine;
using UnityEngine.UI;

public class getToggleValue : MonoBehaviour
{
    public ToggleGroup toggleGroup; // Toggle Groupへの参照
    public static string gender = "";
    public static string targetGender = "";

    // Start is called before the first frame update
    void Start()
    {
        // すでに登録されているリスナーをクリア
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.RemoveAllListeners();
        }

        // Toggle Group内のすべてのToggleに対して新しいイベントリスナーを追加
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener((bool value) => OnToggleValueChanged(toggle, value));
        }
    }

    // Toggleの値が変更されたときに呼ばれるメソッド
    void OnToggleValueChanged(Toggle toggle, bool value)
    {
        if (value)
        {
            // Toggleがオンになった場合の処理
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

    // すべてのToggleの状態をログに表示するメソッド（デバッグ用）
    public void LogToggleStates()
    {
        foreach (Toggle toggle in toggleGroup.GetComponentsInChildren<Toggle>())
        {
            Debug.Log("Toggle " + toggle.gameObject.name + " is " + (toggle.isOn ? "ON" : "OFF"));
        }
    }
}
