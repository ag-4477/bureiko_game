using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameObject breikoBar;
    public GameObject jsonPathLoader;
    private JsonPathLoader jsonPathLoaderScript;
    public GameDataWrapper questionData;
    private BreikoBar breikoBarScrit;
    void Start()
    {
        breikoBarScrit = breikoBar.GetComponent<BreikoBar>();
    }
    public void LoadJson()
    {
        jsonPathLoaderScript = jsonPathLoader.GetComponent<JsonPathLoader>();
        questionData = jsonPathLoaderScript.gameData;
    }
    public void ButtonPressed(int buttinId)
    {
        if(breikoBarScrit != null)
        {
            breikoBarScrit.UpdateBreikoValue(buttinId);
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
            Debug.LogWarning("対象にBreikoBarスクリプトがついていません！");
        }
    }
}
