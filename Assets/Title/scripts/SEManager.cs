using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SEManager : MonoBehaviour
{
    AudioSource AudioSourceSE;

    public static SEManager Instance
    {
        get; protected set;
    }
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        AudioSourceSE = this.GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        AudioSourceSE.PlayOneShot(AudioSourceSE.clip);
    }
}
