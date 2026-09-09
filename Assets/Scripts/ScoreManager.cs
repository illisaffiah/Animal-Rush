using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for loading scenes

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int winScore = 10; // The score needed to complete the level

    public TextMeshProUGUI scoreText;
    public GameObject levelCompletePanel; // Reference to the UI Panel

    void Start()
    {
        // Ensure the game runs at normal speed on start and panel is hidden
        Time.timeScale = 1f;
        levelCompletePanel.SetActive(false);
        UpdateScoreDisplay();
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreDisplay();

        // Check if the player reached the win score
        if (score >= winScore)
        {
            LevelCompleted();
        }
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    private void LevelCompleted()
    {
        // Show the panel and stop time
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Function for the Restart Button
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Unpause before loading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function for the Next Level Button
    public void NextLevel()
    {
        Time.timeScale = 1f; // Unpause before loading

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next scene index exists in the Build Settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // If there are no more levels, loop back to the first level (Index 0)
            Debug.Log("Final level complete! Returning to start.");
            SceneManager.LoadScene(0);
        }
    }
}