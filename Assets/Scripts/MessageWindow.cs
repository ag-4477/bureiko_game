using UnityEngine;
using TMPro;

public class MessageWindow : MonoBehaviour
{
    // メッセージを表示するTMPコンポーネントを紐付ける
    [SerializeField] private TextMeshProUGUI messageText;

    // 外部のスクリプトからこのメソッドを呼んでテキストを書き換える
    public void DisplayMessage(string text)
    {
        if (messageText != null)
        {
            messageText.text = text;
        }
        else
        {
            Debug.LogWarning("メッセージテキストが設定されていません！");
        }
    }

    // 必要であれば、テキストを空にする（ウィンドウを隠す）メソッド
    public void ClearMessage()
    {
        if (messageText != null)
        {
            messageText.text = "上司のありがた～いお言葉";
        }
    }
}