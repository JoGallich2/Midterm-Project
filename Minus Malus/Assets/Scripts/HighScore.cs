using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text UI_Text;
    static private int highScore = 0;

    void Awake()
    {
        UI_Text = GetComponent<Text>();

        // Load the high score from PlayerPrefs if it exists
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        // Set the high score to the current value of SCORE (for display purposes)
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    // Property for accessing and updating the score
    static public int SCORE
    {
        get { return highScore; }
        private set
        {
            highScore = value;
            PlayerPrefs.SetInt("HighScore", value);

            if (UI_Text != null)
            {
                UI_Text.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    // Method to check if the given score is a new high score
    static public void Try_Set_High_Score(int scoreToTry)
    {
        // If the score is lower than the current high score, do nothing
        if (scoreToTry <= highScore)
        {
            return;
        }

        // Otherwise, update the high score
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos()
    {
        // Reset the high score if the checkbox is checked
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 0);
            Debug.LogWarning("PlayerPrefs HighScore reset to 0.");
        }
    }
}
