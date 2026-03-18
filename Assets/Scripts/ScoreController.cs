using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject breikoBar;
    public GameManager gameManager;
    // public GameObject jsonPathLoader;
    private JsonPathLoader jsonPathLoaderScript;
    private ButtonController buttonControllerScript;
    public GameDataWrapper questionData;
    private BreikoBar breikoBarScript;
    public int questionId;
    public float timeLimit = 5.0f; // 制限時間（秒）
    private float timer;           // 現在の経過時間
    private bool isWaiting = false; // 入力待ち状態かどうか
    void Start()
    {
        breikoBarScript = breikoBar.GetComponent<BreikoBar>();
        buttonControllerScript = gameObject.GetComponent<ButtonController>();
        questionId = 0;
        timer = 0f;
        isWaiting = true;
    }
    public void LoadJson()
    {
        jsonPathLoaderScript = gameObject.GetComponent<JsonPathLoader>();
        questionData = jsonPathLoaderScript.gameData;
        if(questionData != null)
        {
            Debug.Log("Data読み込みdone");
        }
        else
        {
            Debug.LogWarning("Data読み込み失敗");
        }
    }
    void Update()
    {
        if (isWaiting)
        {
            timer += Time.deltaTime;
            if (timer >= timeLimit)
            {
                Debug.Log("タイムアップ！次の問題へ");
                NextQuestion(-1); // タイムアップ時はIDとして-1などを渡す（スコア加算なし）
            }
        }
    }

    public void ButtonPressed(int buttonId)
    {
        if (!isWaiting) return; // すでに処理中なら受け付けない
        NextQuestion(buttonId);
    }
    public void NextQuestion(int buttonId)
    {
        timer = 0f; // タイマーリセット
        if(breikoBarScript != null)
        {
            // 1. ゲージの更新
            if (buttonId >= 0)
            {
                breikoBarScript.UpdateBreikoValue(buttonId);
            }

            // 2. 爆発判定（5問終了より先に、爆発したかチェック）
            int breikoValue = breikoBarScript.bureikoBarValue;
            if(breikoValue >= 100)
            {
                Debug.Log("爆発！");
                isWaiting = false;
                if (gameManager != null) gameManager.EndGame(false);
                return; // 爆発したらここで終了
            }

            // 3. 5問終了判定
            // questionIdは0から始まるので、4問目の処理が終わって5になったら終了
            questionId++;
            if (questionId >= 5) 
            {
                Debug.Log("5問終了！判定へ");
                isWaiting = false;
                
                if (gameManager != null)
                {
                    // GameManager側のCheckGameResultを使って勝敗を決める
                    bool win = gameManager.CheckGameResult();
                    gameManager.EndGame(win);
                }
                return;
            }

            // 4. まだ5問未満なら次の問題をセット
            buttonControllerScript.NextBreiko(questionId);
        }
    }
}
