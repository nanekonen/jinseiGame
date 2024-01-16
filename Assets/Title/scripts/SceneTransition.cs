using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    //target
    public string targetSceneName;

    void Start()
    {
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }
    }
    void OnButtonClicked()
    { 
        SceneManager.LoadScene(targetSceneName);
    }
}
