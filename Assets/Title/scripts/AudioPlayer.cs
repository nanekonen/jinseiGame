using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
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
        
    }
}
