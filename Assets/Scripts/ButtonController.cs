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
        data = loader.gameData;
        buttons = GameObject.FindGameObjectsWithTag("choices");
        Debug.Log(buttons);

        List<Button> scriptListTemp = new List<Button>();

        foreach (GameObject button in buttons)
        {
            Button buttonScript = button.GetComponent<Button>();
            if(buttonScript != null)
            {
                scriptListTemp.Add(buttonScript);
            }
        }
        Debug.Log(scriptListTemp);

        buttonScripts = scriptListTemp.ToArray();
    }

    public void NextBreiko(int currentQuestionId)
    {
        int i = 0;
        foreach (Button buttonScript in buttonScripts)
        {
            buttonScript.UpdateButtonText(currentQuestionId, data.questions[currentQuestionId].questiondata[i].data.text);
            Debug.Log(buttonScript.buttonName);
            i++;
        }
    }
}
