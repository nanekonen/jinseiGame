using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMPlayer : MonoBehaviour
{
    bool DontDestroyEnabled = true;
    AudioSource MyAudioSource;

    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
        MyAudioSource.Play();
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
        }
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "gameScene")
        {
            MyAudioSource.Stop();
        }
    }

    void SceneLoaded()
    {
        if(SceneManager.GetActiveScene().name == "inputForm")
        {
            gameObject.SetActive(false);
        }
    }

}
