using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSizeManager : MonoBehaviour
{
    private float scaleRate;
    // Start is called before the first frame update
    void Update()
    {
        this.GetComponent<Image>().preserveAspect = true;
        this.GetComponent<Image>().SetNativeSize();
        Vector2 CanvasSize = transform.root.GetComponent<RectTransform>().sizeDelta;
        Vector2 ThisImageSize = this.GetComponent<RectTransform>().sizeDelta;
        if(CanvasSize.x<CanvasSize.y)
        {
            scaleRate = CanvasSize.x / ThisImageSize.x;
        }
        else
        {
            scaleRate = CanvasSize.y / ThisImageSize.y;
        }
        this.GetComponent<RectTransform>().localScale = new Vector3(scaleRate, scaleRate, 1);
    }
}
