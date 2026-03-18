using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChangeCharactorImage : MonoBehaviour
{
    private Image img;
    private GameObject obj;
    bar bureikoBarScript;

    void Start()
    {
        img = GameObject.Find("Man").GetComponent<Image>();
    }

    void Change()
    {
        obj = GameObject.Find("Slider");
        bureikoBarScript = obj.GetComponent<bar>();

        if (bureikoBarScript.bureikoBarValue < 40)
        {
            img.sprite = 
        }
    }
}