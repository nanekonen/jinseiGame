using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormTransition : MonoBehaviour
{
    [SerializeField]
    public CanvasGroup currentCanvasGroup;
    public CanvasGroup destinationCanvasGroup;
    public Button TriggerButton;

    void Start()
    {
        if(TriggerButton != null)
        {
            TriggerButton.onClick.AddListener(OnButtonClick);
        }

    }

    void OnButtonClick()
    {
        currentCanvasGroup.alpha = 0;
        destinationCanvasGroup.alpha = 1;
    }

}
