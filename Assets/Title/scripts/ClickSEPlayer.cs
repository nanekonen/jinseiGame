using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickSEPlayer : MonoBehaviour
{
    public AudioClip buttonSE;
    public AudioClip paperSE;
    private AudioSource audioSource;
    public Button targetButton;
    private string currentSceneName;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0) && currentSceneName == "prologue")
        {
            PlayClickSound();
        }
       if(currentSceneName != "prologue" && targetButton != null)
        {
            targetButton.onClick.AddListener(OnButtonClicked);
        }
    }

    void PlayClickSound()
    {
        audioSource.PlayOneShot(paperSE);
    }

    private void OnButtonClicked()
    {
        audioSource.PlayOneShot(buttonSE);
    }
}