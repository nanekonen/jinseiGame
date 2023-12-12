using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmAudioSource;
    private string currentBGM;

    // managing dictionary
    private System.Collections.Generic.Dictionary<string, AudioClip> bgmDictionary;

    void Awake()
    {
        // not allow duplicate instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        // initialize
        bgmDictionary = new System.Collections.Generic.Dictionary<string, AudioClip>();
        // set bgm
        bgmDictionary.Add("title", Resources.Load<AudioClip>("BGM/Scene1BGM"));
        bgmDictionary.Add("InputForm", Resources.Load<AudioClip>("BGM/Scene2BGM"));

        // when changing scene, register method
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // changingBGM
        if (bgmDictionary.ContainsKey(scene.name))
        {
            PlayBGM(scene.name);
        }
    }

    // play BGM
    public void PlayBGM(string bgmName)
    {
        if (bgmDictionary.ContainsKey(bgmName))
        {
            // changing BGM without corespondancing current BGM
            if (bgmAudioSource.isPlaying && currentBGM == bgmName)
            {
                return;
            }

            bgmAudioSource.Stop();
            bgmAudioSource.clip = bgmDictionary[bgmName];
            bgmAudioSource.Play();
            currentBGM = bgmName;
        }
        else
        {
            Debug.LogError("BGM not found: " + bgmName);
        }
    }

    // stop BGM
    public void StopBGM()
    {
        bgmAudioSource.Stop();
        currentBGM = null;
    }
}
