using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    
    public GameObject targetobject;
    public TextMeshProUGUI CountText;
    AudioSource audioSource;
    float delay = 1.0f;
    int CountText2 = 3;


    void Start()
    {
        CountText.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeButtonClick); 
        audioSource = targetobject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale == 0)
                ResumeButtonClick(); 
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        audioSource.Pause();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        audioSource.UnPause();
    }

    private void ResumeButtonClick()
    {
        CountText.gameObject.SetActive(true);
        pausePanel.SetActive(false);
        StartCoroutine(Coroutine()); // コルーチンを開始して一定時間後に ResumeGame() を呼び出す
    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSecondsRealtime(delay);
        CountText2 -= 1;
        CountText.text = CountText2.ToString();
        yield return new WaitForSecondsRealtime(delay);
        CountText2 -= 1;
        CountText.text = CountText2.ToString();
        yield return new WaitForSecondsRealtime(delay);
        ResumeGame();
        CountText.gameObject.SetActive(false);
    }
}