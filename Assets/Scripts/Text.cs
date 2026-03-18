using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class Text : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int id;
    public string bossMessage;
    [SerializeField] private TextMeshProUGUI BossText;
    void Start()
    {
        
    }
    public void UpdateBossText(string bossText)
    {
        bossMessage = bossText;
        SetBossText();
        
    }

    public void SetBossText()
    {
        if (BossText != null)
        {
            BossText.text = bossMessage;
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
