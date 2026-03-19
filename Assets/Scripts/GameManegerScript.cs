using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("参照設定")]
    public BreikoBar breikoBar;

    [Header("UI設定")]
    [SerializeField] private GameObject clearPanel;    // クリア時に出すパネル
    [SerializeField] private GameObject gameOverPanel; // 失敗時に出すパネル

    [Header("ゲーム設定")]
    public int clearThreshold = 50;
    public float timeLimit = 10f;

    [Header("デバッグ表示（読み取り専用）")]
    [SerializeField] private float currentTimer; // Inspectorで残り時間を確認するため

    private bool isTimerRunning = false;
    public static bool isGameActive { get; private set; } 
    private float maxLimit;

    void Start()
    {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM("RPG_Battle_04_BGM");
        // パネルの初期化
        if (clearPanel != null) clearPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        // 状態のリセット
        Time.timeScale = 1f; 
        isGameActive = true;   
        isTimerRunning = true;
        currentTimer = timeLimit;

        if (breikoBar != null && breikoBar.BureikoBar != null)
        {
            maxLimit = breikoBar.BureikoBar.maxValue;
        }
    }

    void Update()
    {
        // ゲームがアクティブでない、またはタイマーが動いていないなら何もしない
        if (!isGameActive || !isTimerRunning) return;

        // タイマーのカウントダウン
        currentTimer -= Time.deltaTime;
        // Debug.Log(currentTimer);
        // 0以下になった瞬間の判定
        if (currentTimer <= 0)
        {
            currentTimer = 0;
            isTimerRunning = false; // 二重にEndGameが呼ばれないように停止

            // クリア判定
            CheckGameResult();
        }
    }

    public bool CheckGameResult()
    {
        if (breikoBar != null && breikoBar.bureikoBarValue >= clearThreshold)
        {
            return true;
        }
        else
        {
            return false; // 失敗
        }
    }

    public void EndGame(bool isWin)
    {
        SoundManager.Instance.StopBGM();
        Debug.Log(isWin ? "ゲームクリア！" : "ゲームオーバー！");
        isGameActive = false;
        isTimerRunning = false;
        Time.timeScale = 0f; // ゲームを完全停止

        if (isWin) 
        {
            Debug.Log("CLEAR!");
            SoundManager.Instance.PlaySE("stageClearSE");
            if (clearPanel != null) clearPanel.SetActive(true);
        } 
        else 
        {
            Debug.Log("GAME OVER");
            SoundManager.Instance.PlaySE("stagefailedSE");
            if (gameOverPanel != null) gameOverPanel.SetActive(true);
        }
    }

    // --- ボタン用関数 ---

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}