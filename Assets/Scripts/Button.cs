using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Button : MonoBehaviour
{
    public string buttonName;
    private int id;
    [SerializeField] private TextMeshProUGUI tmpText;

    // void Start()
    // {
    //     UpdateAllButtons();
    // }

    public void UpdateButtonText(int buttonId,string buttonText)
    {
        buttonName = buttonText;
        id = buttonId;
        SetTextDirectly();
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
        SetTextDirectly();
    }
}