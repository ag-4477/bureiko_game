using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject breikoBar;
    public GameObject jsonPathLoader;
    private JsonPathLoader jsonPathLoaderScript;
    public GameDataWrapper questionData;
    private BreikoBar breikoBarScript;
    void Start()
    {
        breikoBarScript = breikoBar.GetComponent<BreikoBar>();
    }
    public void LoadJson()
    {
        jsonPathLoaderScript = jsonPathLoader.GetComponent<JsonPathLoader>();
        questionData = jsonPathLoaderScript.gameData;
    }
    public void ButtonPressed(int buttinId)
    {
        if(breikoBarScript != null)
        {
            breikoBarScript.UpdateBreikoValue(buttinId);
        }
        else
        {
            Debug.LogWarning("対象にBreikoBarスクリプトがついていません！");
        }
        if(questionData != null)
        {
            Debug.Log("Data読み込みdone");
        }
        else
        {
            Debug.LogWarning("Data読み込み失敗");
        }
    }
}
