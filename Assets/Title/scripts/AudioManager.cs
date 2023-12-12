using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmAudioSource;
    private string currentBGM;

    // シーンごとのBGMを管理するディクショナリ
    private System.Collections.Generic.Dictionary<string, AudioClip> bgmDictionary;

    void Awake()
    {
        // AudioManagerが1つだけ存在するようにする
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

        // AudioSourceコンポーネントを取得
        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        // BGMを管理するディクショナリの初期化
        bgmDictionary = new System.Collections.Generic.Dictionary<string, AudioClip>();
        // シーンごとのBGMを追加（必要に応じて拡充）
        bgmDictionary.Add("Scene1", Resources.Load<AudioClip>("BGM/Scene1BGM"));
        bgmDictionary.Add("Scene2", Resources.Load<AudioClip>("BGM/Scene2BGM"));

        // シーンが切り替わるたびに呼び出されるメソッドを登録
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // シーンがロードされたときにBGMを切り替え
        if (bgmDictionary.ContainsKey(scene.name))
        {
            PlayBGM(scene.name);
        }
    }

    // BGMを再生
    public void PlayBGM(string bgmName)
    {
        if (bgmDictionary.ContainsKey(bgmName))
        {
            // 同じBGMが再生中でない場合のみ切り替える
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

    // BGMを停止
    public void StopBGM()
    {
        bgmAudioSource.Stop();
        currentBGM = null;
    }
}
