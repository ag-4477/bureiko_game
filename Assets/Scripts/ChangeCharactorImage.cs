using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ChangeCharactorImage : MonoBehaviour
{
    public SpriteRenderer sr;

    private Image img;
    private GameObject obj;
    BreikoBar bureikoBarScript;
    RectTransform rectTransform;

    void Start()
    {
        img = GameObject.Find("Man").GetComponent<Image>();
    }

    void Update()
    {
        obj = GameObject.Find("Slider");
        bureikoBarScript = obj.GetComponent<BreikoBar>();

        if (bureikoBarScript.bureikoBarValue < 40)
        {
            img.sprite = Resources.Load<Sprite>("Charactor/senpai/normal");
        } 
        else if (bureikoBarScript.bureikoBarValue > 40 && bureikoBarScript.bureikoBarValue < 80)
        {
            img.sprite = Resources.Load<Sprite>("Charactor/senpai/angry");
        }
        else if (bureikoBarScript.bureikoBarValue > 80)
        {
            img.sprite = Resources.Load<Sprite>("Charactor/senpai/superAngry");
        }
    }
}