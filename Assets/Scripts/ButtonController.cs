using UnityEngine;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    // int currentQuestionId;
    public JsonPathLoader loader;
    private GameDataWrapper data;
    private List<Button> buttons;

    
    void Start()
    {
        loader = gameObject.GetComponent<JsonPathLoader>();
        data = loader.gameData;
    }

    void NextBreiko(int currentQuestionId)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].UpdateButtonText(currentQuestionId, data.questions[currentQuestionId].questiondata[i].data.text);
            Debug.Log(buttons[i].buttonName);
        }
    }
}
