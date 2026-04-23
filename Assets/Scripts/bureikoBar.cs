using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 無礼講バーの制御を行います。
/// </summary>
/// <param name="bureikoBarValue">無礼講バーにたまっている無礼講ポイント</param>
/// 
public class BreikoBar : MonoBehaviour
{
    [SerializeField]
    public int bureikoBarValue;
    public Slider BureikoBar;
    private SliderTransition sliderTransitionScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // BureikoBar = gameObject;
        bureikoBarValue = 0;
        BureikoBar.value = bureikoBarValue;
    }
    void Awake()
    {
        sliderTransitionScript = gameObject.GetComponent<SliderTransition>();
    }
    public void UpdateBreikoValue(int score)
    {
        bureikoBarValue += score;
        sliderTransitionScript.ChangeSliderValue(bureikoBarValue);
    }
}
