using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCapture : MonoBehaviour
{
    public void HighScoreCapture()
    {
        float currentScore = GManager.score;
        float highScore = PlayerPrefs.GetFloat("HighScore", 0f);

        if(currentScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
            PlayerPrefs.Save();
        }
    }

    public float GetHighScore()
    {
        return PlayerPrefs.GetFloat("HighScore");
    }
}
