using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource bgmAudioSource;
    private string currentBGM;

    // �V�[�����Ƃ�BGM���Ǘ�����f�B�N�V���i��
    private System.Collections.Generic.Dictionary<string, AudioClip> bgmDictionary;

    void Awake()
    {
        // AudioManager��1�������݂���悤�ɂ���
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

        // AudioSource�R���|�[�l���g���擾
        bgmAudioSource = gameObject.AddComponent<AudioSource>();

        // BGM���Ǘ�����f�B�N�V���i���̏�����
        bgmDictionary = new System.Collections.Generic.Dictionary<string, AudioClip>();
        // �V�[�����Ƃ�BGM��ǉ��i�K�v�ɉ����Ċg�[�j
        bgmDictionary.Add("Scene1", Resources.Load<AudioClip>("BGM/Scene1BGM"));
        bgmDictionary.Add("Scene2", Resources.Load<AudioClip>("BGM/Scene2BGM"));

        // �V�[�����؂�ւ�邽�тɌĂяo����郁�\�b�h��o�^
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // �V�[�������[�h���ꂽ�Ƃ���BGM��؂�ւ�
        if (bgmDictionary.ContainsKey(scene.name))
        {
            PlayBGM(scene.name);
        }
    }

    // BGM���Đ�
    public void PlayBGM(string bgmName)
    {
        if (bgmDictionary.ContainsKey(bgmName))
        {
            // ����BGM���Đ����łȂ��ꍇ�̂ݐ؂�ւ���
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

    // BGM���~
    public void StopBGM()
    {
        bgmAudioSource.Stop();
        currentBGM = null;
    }
}
