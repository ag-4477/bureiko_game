using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneChangeTitle : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM("introBGM");
    }
    public string sceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}