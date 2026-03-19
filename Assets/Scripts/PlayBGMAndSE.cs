using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    // 内部管理用の辞書（ファイル名がキーになります）
    private Dictionary<string, AudioClip> bgmDict = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> seDict = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            // Resourcesフォルダから自動ロード
            LoadResources();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadResources()
    {
        // Assets/Resources/SE_BGM 内のファイルをすべて取得
        // フォルダ分けしている場合は "SE_BGM/BGM" のように指定も可能
        AudioClip[] clips = Resources.LoadAll<AudioClip>("SE_BGM");

        foreach (var clip in clips)
        {
            // 名前でBGMかSEか判定（例：ファイル名に "BGM" が含まれるか、特定のルールで分ける）
            // もしフォルダを分けているなら、clipのパスで判定も可能です。
            if (clip.name.Contains("BGM")) 
            {
                bgmDict[clip.name] = clip;
            }
            else 
            {
                seDict[clip.name] = clip;
            }
        }
        
        Debug.Log($"Loaded: BGM {bgmDict.Count} files, SE {seDict.Count} files.");
    }

    public void PlayBGM(string soundName, bool loop = true)
    {
        if (bgmDict.TryGetValue(soundName, out AudioClip clip))
        {
            if (bgmSource.clip == clip && bgmSource.isPlaying) return;
            bgmSource.clip = clip;
            bgmSource.loop = loop;
            bgmSource.Play();
        }
        else
        {
            Debug.LogWarning($"BGM: {soundName} が見つかりません");
        }
    }

    public void PlaySE(string soundName)
    {
        if (seDict.TryGetValue(soundName, out AudioClip clip))
        {
            seSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SE: {soundName} が見つかりません");
        }
    }
    // BGMを停止する
    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
    }
}