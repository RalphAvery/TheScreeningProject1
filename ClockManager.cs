using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    [Header("Fade Settings")]
    public float fadeDurationStart = 1.0f; // Duration of the screen fading effect at the beginning
    public float fadeDurationEnd = 1.0f; // Duration of the screen fading effect at the end
    public float endTime = 6.0f; // Time when the game should close (in hours)
    public float timeScale = 1.0f; // Time scale factor to control the speed of the clock

    [Header("References")]
    public EndGameScreenFader screenFader; // Reference to the ScreenFader component
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component for timer

    private bool isFading = false; // Flag to prevent multiple fading processes
    private float startTime; // Start time of the game

    private void Start()
    {
        // Record the start time of the game
        startTime = Time.time;

        // Start the timer at 12:00 AM when the game starts
        UpdateTimer(0);
    }

    private void Update()
    {
        if (!isFading)
        {
            // Get the current elapsed time since the start of the game, scaled by timeScale
            float currentTime = (Time.time - startTime) / 3600.0f * timeScale; // Convert time to hours with time scale

            // Ensure the clock stops at the specified end time
            currentTime = Mathf.Min(currentTime, endTime);

            // Update the timer
            UpdateTimer(currentTime);

            // Check if it's time to start fading (only when it's exactly 6:00 AM)
            if (Mathf.Approximately(currentTime, endTime)) // Check if currentTime is approximately equal to endTime
            {
                StartFading();
            }
        }
    }

    private void UpdateTimer(float time)
    {
        // Calculate hours and minutes
        int hours = Mathf.FloorToInt(time);
        int minutes = Mathf.FloorToInt((time - hours) * 60);

        // Convert 0 hours to 12 AM
        if (hours == 0)
        {
            hours = 12;
        }

        // Display the timer in format "HH:MM AM"
        timerText.text = hours.ToString("00") + ":" + minutes.ToString("00") + " AM";
    }

    private void StartFading()
    {
        // Start the screen fading effect with the fade duration at the end
        screenFader.StartFading(fadeDurationEnd);

        // Set the flag to prevent multiple fading processes
        isFading = true;
    }
}
