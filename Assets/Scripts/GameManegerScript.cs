using UnityEngine;
using UnityEngine.SceneManagement; // シーン移動に必要

public class GameManager : MonoBehaviour
{
    [Header("参照設定")]
    public BreikoBar breikoBar;

    [Header("UI設定")]
    [SerializeField] private GameObject clearPanel;    // クリア時に出すパネル
    [SerializeField] private GameObject gameOverPanel; // 失敗時に出すパネル

    [Header("ゲーム設定")]
    public int clearThreshold = 70;
    public float timeLimit = 30f;

    private float timer;
    public static bool isGameActive { get; private set; } 
    private float maxLimit;

    void Start()
    {
        // 最初はパネルを隠しておく
        clearPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        // 時間とフラグのリセット
        Time.timeScale = 1f; 
        isGameActive = true;   
        timer = timeLimit;

        if (breikoBar != null && breikoBar.BureikoBar != null)
        {
            maxLimit = breikoBar.BureikoBar.maxValue;
        }
    }

    void Update()
    {
        if (!isGameActive) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
            // 時間終了時の判定
            if (breikoBar.bureikoBarValue >= clearThreshold)
                EndGame(true);
            else
                EndGame(false);
        }
    }

    void EndGame(bool isWin)
    {
        isGameActive = false;
        Time.timeScale = 0f; // ゲームを停止

        if (isWin) 
        {
            Debug.Log("CLEAR!");
            clearPanel.SetActive(true); // クリアパネルを表示
        } 
        else 
        {
            Debug.Log("GAME OVER");
            gameOverPanel.SetActive(true); // 失敗パネルを表示
        }
    }

    // --- ボタンから呼ぶための関数 ---

    public void Retry()
    {
        // 現在のシーンを最初から読み直す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToTitle()
    {
        // "Title" という名前のシーンへ（シーン名は自分の設定に合わせてください）
        SceneManager.LoadScene("Title");
    }
}