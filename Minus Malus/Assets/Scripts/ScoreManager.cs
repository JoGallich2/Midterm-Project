using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score : " + score; 
    }
}
