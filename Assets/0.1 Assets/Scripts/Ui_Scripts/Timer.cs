using UnityEngine;
using UnityEngine.UI;


namespace ItsaMeKen
{
    public class Timer : MonoBehaviour
    {
        public float duration = 10f;
        public bool isRunning = false;
        public bool autoStart = true;

        private float timeRemaining;

        public delegate void TimerFinishedDelegate();
        public event TimerFinishedDelegate TimerFinished;

        public Text timerText;

        void Start()
        {
            if (autoStart)
            {
                StartTimer();
            }
        }

        void Update()
        {
            if (isRunning)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 0f)
                {
                    isRunning = false;
                    timeRemaining = 0f;
                    TimerFinished?.Invoke();
                }
                UpdateTimerText();
            }
        }

        public void StartTimer()
        {
            timeRemaining = duration;
            isRunning = true;
            UpdateTimerText();
        }

        public void StopTimer()
        {
            isRunning = false;
        }

        public void ResetTimer()
        {
            timeRemaining = duration;
        }

        public float GetTimeRemaining()
        {
            return timeRemaining;
        }

        public bool IsTimerRunning()
        {
            return isRunning;
        }

        private void UpdateTimerText()
        {
            if (timerText != null)
            {
                timerText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
            }
        }
    }
}