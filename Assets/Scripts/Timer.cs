using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshPro timerText; // Reference to the UI Text component to display the timer

    private float startTime; // Time when the timer starts
    private float elapsedTime; // Time elapsed since the timer started
    private bool isTimerRunning = false; // Flag to control the timer

    void Start()
    {
        startTime = Time.time; // Record the start time
    }

    void Update()
    {
        // Calculate the elapsed time
        elapsedTime = Time.time - startTime;

        // Format the time as minutes:seconds
        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");

        // Update the UI text to display the timer
        timerText.text = minutes + ":" + seconds;
    }
    
    public void StartTimer()
    {
        startTime = Time.time; // Record the start time
        isTimerRunning = true; // Start the timer
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public void StopTimer()
    {
        isTimerRunning = false; // Stop the timer
    }
}