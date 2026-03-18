using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject breikoBar;
    // public GameObject jsonPathLoader;
    private JsonPathLoader jsonPathLoaderScript;
    private ButtonController buttonControllerScript;
    public GameDataWrapper questionData;
    private BreikoBar breikoBarScript;
    public int questionId;
    void Start()
    {
        breikoBarScript = breikoBar.GetComponent<BreikoBar>();
        buttonControllerScript = gameObject.GetComponent<ButtonController>();
        questionId = 0;
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
    public void ButtonPressed(int buttonId)
    {
        if(breikoBarScript != null)
        {
            breikoBarScript.UpdateBreikoValue(buttonId);
            buttonControllerScript.NextBreiko(questionId);
            questionId++;
        }
        else
        {
            Debug.LogWarning("対象にBreikoBarスクリプトがついていません！");
        }
    }
}
