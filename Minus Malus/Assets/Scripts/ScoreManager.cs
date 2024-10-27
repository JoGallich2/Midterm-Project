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
    private int score = 0;
    private int currentLevel = 1;
   
    [Header("Dynamic")]

    public int levels = 3;
    public int maxScore = 100; // Set this to the maximum score the slider can reach

    // Add points to the current score
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score + " Points";
        scoreSlider.value = score;

        // Check if the score reaches the max value of the slider
        if (score >= maxScore)
        {
            LevelUp();
        }
    }

    // Call this method when the game should go to the next level
    public void LevelUp()
    {
        if(currentLevel < levels)
        {
            currentLevel++;
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
        HighScore.Try_Set_High_Score(score);

        // Load the end game scene
        SceneManager.LoadScene("EndGame");
    }
}
