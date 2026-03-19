using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class SliderBlinker : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [Header("点滅の設定")]
    [SerializeField] private float oneBlinkDuration = 0.5f; // 1回の点滅（フェードイン＋フェードアウト）にかかる時間
    [SerializeField] private int blinkCount = 3;           // 点滅回数

    [Header("点滅の動き（カーブ）")]
    // インスペクターで、0から1へ行って戻るようなカーブを設定します
    [SerializeField] private AnimationCurve blinkCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // 最初は表示しておく（必要に応じて0にする）
        canvasGroup.alpha = 1f;
    }

    // 外部から呼ぶ関数（テスト用にStartで呼んでもOK）
    public void StartSmoothBlinking()
    {
        StopAllCoroutines(); // 二重再生防止
        StartCoroutine(SmoothBlinkRoutine());
    }

    private IEnumerator SmoothBlinkRoutine()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            float timer = 0f;

            // 1回の点滅時間（oneBlinkDuration）をかけてカーブを再生
            while (timer < oneBlinkDuration)
            {
                timer += Time.deltaTime;
                // 現在の時間の割合（0.0 〜 1.0）を計算
                float normalizedTime = timer / oneBlinkDuration;

                // カーブからその時点のAlpha値を取得して適用
                // カーブの設定例：(0,1) -> (0.5,0) -> (1,1) だと、パッと消えて戻る
                // カーブの設定例：(0,0) -> (0.5,1) -> (1,0) だと、ふわっと付いて消える
                canvasGroup.alpha = blinkCurve.Evaluate(normalizedTime);

                yield return null; // 1フレーム待つ
            }
        }

        // 最後に完全に表示状態に戻す（または消す）
        canvasGroup.alpha = 1f;

        OnBlinkFinished();
    }

    private void OnBlinkFinished()
    {
        Debug.Log("緩やかな点滅が終了しました。");
        // 次の処理へ
    }

    // --- テスト用 ---
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartSmoothBlinking();
        }
    }
}