using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SliderTransition : MonoBehaviour
{
    public Slider mySlider;
    public float TransitionTime;

    void Awake()
    {
        mySlider = gameObject.GetComponent<Slider>();
        if (mySlider == null)
        {
            Debug.LogError("Sliderが見つかりません！同じオブジェクトにアタッチされていますか？");
        }
    }

    // このメソッドを呼ぶと、指定した値まで滑らかに動く
    public void ChangeSliderValue(int targetValue)
    {
        // 現在の値から targetValue まで、1.0秒かけて変化させる
        mySlider.DOValue(targetValue, TransitionTime);
    }
}