using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetScores : MonoBehaviour
{
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        // Retrieve the final score and high score from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Update the TMP_Text fields
        currentScoreText.text = "Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;
    }
}
