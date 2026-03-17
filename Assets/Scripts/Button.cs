using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class ButtonData : MonoBehaviour
{
    private string buttonName;
    private int id;
    public static string[] buttonTexts = { "なし", "りんご", "みかん", "バナナ", "ぶどう" };
    [SerializeField] private TextMeshProUGUI tmpText;

    void Start()
    {
        UpdateAllButtons();
    }

    public void UpdateAllButtons()
    {
        ButtonData[] allButtons = Object.FindObjectsByType<ButtonData>(FindObjectsSortMode.None);
        List<int> randomIds = Enumerable.Range(0, buttonTexts.Length).OrderBy(x => System.Guid.NewGuid()).ToList();

        for (int i = 0; i < allButtons.Length; i++)
        {
            if (i < randomIds.Count)
            {
                allButtons[i].id = randomIds[i];
                allButtons[i].buttonName = buttonTexts[randomIds[i]];
                allButtons[i].SetTextDirectly();
            }
        }
    }

    public void SetTextDirectly()
    {
        if (tmpText != null)
        {
            tmpText.text = buttonName;
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("ID: " + id + " (" + buttonName + ") が押されました");
        UpdateAllButtons();
    }
}