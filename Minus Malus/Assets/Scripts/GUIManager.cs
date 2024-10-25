using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public TMP_Text TimeText;
    public Button ButtonS;
    public float timeRemaining = 120f;
    private bool timerIsRunning = false;


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
                // Add logic here if you want something to happen when the timer reaches 0
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
