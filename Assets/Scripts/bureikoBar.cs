using UnityEngine;
using UnityEngine.UI;

public class bar : MonoBehaviour
{
    [SerializeField]
    public int bureikoBarValue;
    public Slider BureikoBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bureikoBarValue = 0;
        BureikoBar.value = bureikoBarValue;
    }
    void UpdateBreikoValue(int score)
    {
        bureikoBarValue += score;
        BureikoBar.value = bureikoBarValue;
    }
}
