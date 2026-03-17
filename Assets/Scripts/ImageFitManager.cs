// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ImageFitManager : MonoBehaviour
// {
//     private float scaleRate;
    
//     void Start()
//     {
//         this.GetComponent().preserveAspect = true;
//         this.GetComponent().SetNativeSize();
//         Vector2 CanvasSize = transform.root.GetComponent().sizeDelta;
//         Vector2 ThisImageSize = this.GetComponent().sizeDelta;
//         if(CanvasSize.x<CanvasSize.y)
//         {
//             scaleRate = CanvasSize.x / ThisImageSize.x;
//         }
//         else
//         {
//             scaleRate = CanvasSize.y / ThisImageSize.y;
//         }
//         this.GetComponent<RectTransform>().localScale = new Vector3(scaleRate, scaleRate, 1);
//     }
// }