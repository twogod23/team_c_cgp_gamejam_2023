using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField]TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    private void OnEnable()
    {
        scoreText.text = GManager.score.ToString();
        perfectText.text = GManager.perfect.ToString();
        greatText.text = GManager.great.ToString();
        badText.text = GManager.bad.ToString();
        missText.text = GManager.miss.ToString();
    }

    public void Retry()
    {
        GManager.perfect = 0;
        GManager.great = 0;
        GManager.bad = 0;
        GManager.miss = 0;
        GManager.maxScore = 0;
        GManager.ratioScore = 0;
        GManager.score = 0;
        GManager.combo = 0;
        SceneManager.LoadScene("MusicScene");
    }
}