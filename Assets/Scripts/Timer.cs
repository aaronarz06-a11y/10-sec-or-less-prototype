using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 10f;
    public TMP_Text timerText;
    public GameObject endScreen;
    public TMP_Text resultsText;
    private float currentTime;
    private bool timerRunning = true;
    private bool gameEnded = false;
    private int targetsHit = 0;

    void Start()
    {
        Time.timeScale = 1f;
        currentTime = timeLimit;
        targetsHit = 0;
        timerRunning = true;
        gameEnded = false;

        if (endScreen != null)
        {
            endScreen.SetActive(false);
        }

        UpdateTimerText();
    }

    void Update()
    {
        if (!timerRunning)
        {
            return;
        }

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            timerRunning = false;

            TimerFinished();
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            if (gameEnded)
            {
                timerText.text = "Time Up!";
            }
            else
            {
                timerText.text = Mathf.Ceil(currentTime).ToString();
            }
        }
    }

    void TimerFinished()
    {
        gameEnded = true;

        if (resultsText != null)
        {
            resultsText.text = "Time Up!\nTargets Hit: " + targetsHit;
        }

        if (endScreen != null)
        {
            endScreen.SetActive(true);
        }

        Time.timeScale = 0f;

        Debug.Log("Time's up!");
    }

    public void TargetHit()
    {
        if (gameEnded)
        {
            return;
        }

        targetsHit++;
    }

    public float GetTime()
    {
        return currentTime;
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}