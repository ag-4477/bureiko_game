using UnityEngine;
using System.IO;

public class JsonPathLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameDataWrapper gameData;
    void Start()
    {
        string filePath = Path.Combine(Application.dataPath, "json", "sample_data.json");

        if (File.Exists(filePath))
        {
            // ファイルの全内容を読み込む
            string jsonText = File.ReadAllText(filePath);
            
            gameData = JsonUtility.FromJson<GameDataWrapper>(jsonText);
            Debug.Log("パス指定での読み込みに成功");
            //Debug.Log(gameData.questions[0].questiondata[1].data.text);
        }
        else
        {
            Debug.LogError("ファイルがない" + filePath);
        }
    }
}