using UnityEngine;
using TMPro;

public class ButtonData : MonoBehaviour
{
    private string buttonName;
    private int id;
    public string[] buttonTexts = { "なし", "りんご", "みかん", "バナナ", "ぶどう" };
    
    [SerializeField] private TextMeshProUGUI tmpText;

    void Start()
    {
        id = Random.Range(0, buttonTexts.Length);
        buttonName = buttonTexts[id];
        UpdateHandleText();
    }

    public void UpdateHandleText()
    {
        tmpText.text = buttonName;
    }

    public void OnButtonClick()
    {
        Debug.Log("ID: " + id + " (" + buttonName + ") が押されました");
    }
}