using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeManager : MonoBehaviour
{
    public float timeLimit = 5.0f;
    public Image timerCircle;
    private float timer;
    private bool isRunning = false;

    // 時間切れを通知するためのイベント
    public event Action OnTimeUp;

    public void StartTimer()
    {
        timer = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
        float ratio = 1.0f - (timer / timeLimit);

        if (timerCircle != null)
        {
            timerCircle.fillAmount = ratio;
            timerCircle.color = Color.Lerp(Color.red, Color.green, ratio);
        }
        if (timer >= timeLimit)
        {
            StopTimer();
            OnTimeUp?.Invoke(); 
        }
    }
}