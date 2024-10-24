using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public Slider ScoreSlider;
    public int score = 0;

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score + " Points";
        ScoreSlider.value = score;
    }
}
