using UnityEngine;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    // int currentQuestionId;
    private JsonPathLoader loader;
    private GameDataWrapper data;
    private GameObject[] buttons;
    private Button[] buttonScripts;
    private DialogueText[] bossTextScripts;

    
    // Start を Awake に変える
    void Awake() 
    {
        // 他のスクリプトから呼ばれる前に、自分のコンポーネントを確保しておく
        loader = gameObject.GetComponent<JsonPathLoader>();
        
        // ボタンの取得も Awake でやっておくと安全です
        buttonScripts = Object.FindObjectsByType<Button>(FindObjectsSortMode.None);

        bossTextScripts = Object.FindObjectsByType<DialogueText>(FindObjectsSortMode.None);
    }

    void Start()
    {
        // Debug用。Awakeで取得済みなので、ここでもう一度やる必要はありません。
        foreach (Button buttonScript in buttonScripts)
        {
            Debug.Log("Found button: " + buttonScript.name);
        }
    }

    public void LoadJson()
    {
        data = loader.gameData;
        if(data != null)
        {
            Debug.Log("Data読み込みdone");
        }
        else
        {
            Debug.LogWarning("Data読み込み失敗");
        }
    }

    public void NextBreiko(int currentQuestionId)
    {
        int i = 0;
        foreach (Button buttonScript in buttonScripts)
        {
            buttonScript.UpdateButtonText(i, data.questions[currentQuestionId].questionSet.questiondata[i].data.text);
            i++;
        }
        DisplayBossText(currentQuestionId);
    }

    public void DisplayBossText(int questionId)
    {
        foreach (DialogueText bossTextScript in bossTextScripts)
        {
            bossTextScript.UpdateBossText(data.questions[questionId].questionSet.bossText);
        }
    }
}