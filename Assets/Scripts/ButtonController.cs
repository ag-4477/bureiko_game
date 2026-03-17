using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdd
    int currentQuestionIndex;
    void Start()
    {
        currentQuestionIndex = 0;
        nextBreiko();
    }

    void nextBreiko()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //シーンが変わったら
        
        currentQuestionIndex++;
    }
}
