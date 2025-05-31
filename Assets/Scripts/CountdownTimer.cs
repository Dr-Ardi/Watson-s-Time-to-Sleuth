using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText;                // Assign your Text UI element in the Inspector
    public int totalTimeInSeconds = 3600;     // 1 hour default, -1 to disable
    public int actionIntervalMinutes = 5;     // Trigger every 5 minutes

    private float timeLeft;
    private float nextActionTime;
    private float nextUpdate = 1f;

    private bool timerEnabled = true;

    void Start()
    {
        if (totalTimeInSeconds == -1)
        {
            timerEnabled = false;
            return; // Do nothing
        }

        timeLeft = totalTimeInSeconds;
        nextActionTime = timeLeft - actionIntervalMinutes * 60;
    }

    void Update()
    {
        if (!timerEnabled)
            return;

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            // Update UI every second (not every frame)
            nextUpdate -= Time.deltaTime;
            if (nextUpdate <= 0f)
            {
                UpdateTimerText();
                nextUpdate = 1f;
            }

            // Trigger action every X minutes
            if (timeLeft <= nextActionTime && nextActionTime > 0)
            {
                TriggerAction();
                nextActionTime -= actionIntervalMinutes * 60;
            }
        }
        else
        {
            timeLeft = 0;
            UpdateTimerText();
            // Optional: Final action or stop here
        }
    }

    void UpdateTimerText()
    {
        TimeSpan time = TimeSpan.FromSeconds(Mathf.Ceil(timeLeft));
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
            time.Hours, time.Minutes, time.Seconds);
    }

    void TriggerAction()
    {
        Debug.Log("Action triggered at " + TimeSpan.FromSeconds(totalTimeInSeconds - timeLeft));
        // Replace this with your actual logic
    }
}
