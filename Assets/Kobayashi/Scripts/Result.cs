using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    [SerializeField] TextMeshProUGUI highScoreText;

    [SerializeField] private string movescene;

    private ScoreCapture scoreCapture;

    void Start()
    {
        scoreCapture = FindObjectOfType<ScoreCapture>(); 
        if (scoreCapture != null)
        {
            float currentScore = GManager.score;
            float highScore = scoreCapture.GetHighScore();
        }
    }

    private void OnEnable()
    {
        scoreText.text = GManager.score.ToString();
        perfectText.text = GManager.perfect.ToString();
        greatText.text = GManager.great.ToString();
        badText.text = GManager.bad.ToString();
        missText.text = GManager.miss.ToString();

        float currentScore = GManager.score;

        if (scoreCapture != null)
        {
            float highScore = scoreCapture.GetHighScore();
            highScoreText.text = Mathf.Max(highScore, currentScore).ToString();
        }
        else
        {
            highScoreText.text = currentScore.ToString();
        }
    }

    public void Title()
    {
        GManager.perfect = 0;
        GManager.great = 0;
        GManager.bad = 0;
        GManager.miss = 0;
        GManager.maxScore = 0;
        GManager.ratioScore = 0;
        GManager.score = 0;
        GManager.combo = 0;
        SceneManager.LoadScene(movescene);
    }
}