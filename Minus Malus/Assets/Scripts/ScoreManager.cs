using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("Inscribed")]
    public TMP_Text scoreText;
    public Slider scoreSlider;
    public int score = 0;
    public int currentLevel;

    [Header("Dynamic")]
    public int levels = 3;
    public int maxScore = 100; // Set this to the maximum score the slider can reach

    void awake()
    {
        currentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }
    void Start()
    {

        // Retrieve the current level from PlayerPrefs, or default to 1
        //currentLevel = PlayerPrefs.GetInt("CurrentLevel");

        // Set the slider's max value to match maxScore
        scoreSlider.maxValue = maxScore;

        // Initialize the score based on the current level
        if (currentLevel == 1)
        {
            PlayerPrefs.SetInt("CurrentScore", 0);
        }
        else
        {
            score = PlayerPrefs.GetInt("CurrentScore");
            AddPoints(0); // Update UI with the retrieved score
        }
        
    }

    // Add points to the current score
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score + " Points";
        scoreSlider.value = score;
        PlayerPrefs.SetInt("CurrentScore", score);

        // Check if the score reaches the max value of the slider
        if (score >= maxScore)
        {
            LevelUp();
        }
    }

    // Call this method when the game should go to the next level
    public void LevelUp()
    {
        if (currentLevel < levels)
        {
            currentLevel++;
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            PlayerPrefs.SetInt("CurrentScore", score);

            string nextLevelName = "Level" + currentLevel;
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            EndGame();
        }
    }

    // Call this method when the game ends
    public void EndGame()
    {
        // Save the final score using PlayerPrefs
        PlayerPrefs.SetInt("FinalScore", score);

        // Try to set the high score using the final score
        PlayerPrefs.SetInt("CurrentScore", score);
        HighScore.Try_Set_High_Score(score);

        // Load the end game scene
        SceneManager.LoadScene("EndGame");
    }
}
