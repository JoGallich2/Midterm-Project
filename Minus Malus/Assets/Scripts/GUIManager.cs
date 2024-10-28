using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [Header("Inscribed")]
    public TMP_Text TimeText;
    public TMP_Text BulletOneCount, BulletTwoCount, BulletThreeCount;
    public TMP_Text CrateCountText;
    private bool timerIsRunning = false;

    [Header("Dynamic")]
    public int OneCount = 50;
    public int TwoCount = 50;
    public int ThreeCount = 50;
    public float timeRemaining = 120f;

    private int CrateCount;
    private ScoreManager scoreManager;



    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                scoreManager.EndGame();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void BulletWasShot(int bulletNumber)
    {
        if(bulletNumber == 1)
        {
            OneCount--;
            BulletOneCount.text = OneCount.ToString();
        }
        else if (bulletNumber == 2)
        {
            TwoCount--;
            BulletTwoCount.text = TwoCount.ToString();
        }
        else if (bulletNumber == 3)
        {
            ThreeCount--;
            BulletThreeCount.text = ThreeCount.ToString();
        }
    }

    public void UpdateCrateCount(int TotalCrates, int CratesDeployed)
    {
        CrateCountText.text = "x" + (TotalCrates - CratesDeployed).ToString();
    }
}
