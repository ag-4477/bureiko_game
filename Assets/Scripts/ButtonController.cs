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

    
    void Start()
    {
        loader = gameObject.GetComponent<JsonPathLoader>();
        buttonScripts = Object.FindObjectsByType<Button>(FindObjectsSortMode.None);
        Debug.Log(buttonScripts);
        foreach (Button buttonScript in buttonScripts)
        {
            Debug.Log(buttonScript);
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
            Debug.Log(currentQuestionId);
            Debug.Log(i);
            buttonScript.UpdateButtonText(currentQuestionId, data.questions[currentQuestionId].questiondata[i].data.text);
            Debug.Log(buttonScript.buttonName);
            i++;
        }
    }
}
