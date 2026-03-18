using UnityEngine;
using UnityEngine.UI;

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
