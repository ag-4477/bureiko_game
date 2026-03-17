using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Button : MonoBehaviour
{
    public GameObject ScoreController;
    private ScoreController scoreControllerScript;
    public string buttonName;
    public int id;
    [SerializeField] private TextMeshProUGUI tmpText;

    void Start()
    {
        ScoreController = GameObject.Find("GameManager");
        scoreControllerScript = ScoreController.GetComponent<ScoreController>();
    }

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
        if(scoreControllerScript != null)
        {
            scoreControllerScript.ButtonPressed(id);
        }
        else
        {
            Debug.LogWarning("対象にBreikoBarスクリプトがついていません！");
        }
    }
}