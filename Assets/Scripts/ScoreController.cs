using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject breikoBar;
    public GameManager gameManager;
    private TimeManager timeManager; // TimeManagerへの参照
    public GameObject timeManegerObject;

    private JsonPathLoader jsonPathLoaderScript;
    private ButtonController buttonControllerScript;
    public GameDataWrapper questionData;
    private BreikoBar breikoBarScript;
    public int questionId;
    private bool isWaiting;

    void Awake()
    {
        timeManager = timeManegerObject.GetComponent<TimeManager>();
        breikoBarScript = breikoBar.GetComponent<BreikoBar>();
        buttonControllerScript = gameObject.GetComponent<ButtonController>();
    }
    void Start()
    {
        isWaiting = false;
        questionId = 0; 

        if (timeManager != null)
        {
            // 時間切れイベント発生時に、自動的に引数-1で自分を呼ぶように登録
            timeManager.OnTimeUp += () => ButtonPressed(-1);
            
            isWaiting = true;
            timeManager.StartTimer();
            buttonControllerScript.NextBreiko(questionId);
        }
        else
        {
            Debug.LogWarning("timeManagerがありません！");
        }
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

    // ボタンから呼ばれる、および時間切れ時に実行されるメイン処理
    public void ButtonPressed(int buttonId)
    {
        if (!isWaiting) return;

        // 次のステップに進むのでタイマーをリセットして開始
        timeManager.StartTimer();

        if(breikoBarScript != null)
        {
            // 1. ゲージの更新
            if (buttonId >= 0)
            {
                Debug.Log("qustionId : "+questionId+"buttonId : "+buttonId);
                int breikoScore = questionData.questions[questionId].questionSet.questiondata[buttonId].data.breikoScore;
                breikoBarScript.UpdateBreikoValue(breikoScore);
            }

            // 2. 爆発判定
            int breikoValue = breikoBarScript.bureikoBarValue;
            if(breikoValue >= 100)
            {
                Debug.Log("爆発！");
                EndGameSequence(false);
                return;
            }

            // 3. 5問終了判定
            questionId++;
            if (questionId >= 5) 
            {
                Debug.Log("5問終了！判定へ");
                if (gameManager != null)
                {
                    EndGameSequence(gameManager.CheckGameResult());
                }
                return;
            }

            // 4. 次の問題をセット
            buttonControllerScript.NextBreiko(questionId);
        }
        else
        {
            Debug.Log("breikobarScriptがありません！");
        }
    }

    // 終了処理の共通化
    private void EndGameSequence(bool isWin)
    {
        isWaiting = false;
        timeManager.StopTimer();
        if (gameManager != null) gameManager.EndGame(isWin);
    }
}