using UnityEngine;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    // int currentQuestionId;
    private JsonPathLoader loader;

    private GameDataWrapper data;
    
    void Start()
    {
        
        data = loader.gameData;

        NextBreiko(0);
    }

    void NextBreiko(int currentQuestionId)
    {
        List<Button> buttons = new List<Button>();

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].UpdateButtonText(currentQuestionId, data.questions[currentQuestionId].questiondata[i].data.text);
            Debug.Log(buttons[i].buttonName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
