using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("Level1");
    }
}
