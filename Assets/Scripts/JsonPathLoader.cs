using UnityEngine;
using System.IO;

public class JsonPathLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameDataWrapper gameData;
    void Start()
    {
        string filePath = "json/sample_data";

        // ファイルの全内容を読み込む
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        if(jsonFile != null)
        {
            string jsonText = jsonFile.text;
            
            gameData = JsonUtility.FromJson<GameDataWrapper>(jsonText);
            Debug.Log("パス指定での読み込みに成功");
            gameObject.GetComponent<ScoreController>().LoadJson();
            gameObject.GetComponent<ButtonController>().LoadJson();
            //Debug.Log(gameData.questions[0].questiondata[1].data.text);            
        }
        else
        {
            Debug.LogError("ファイルがない" + filePath);
        }
    }
}