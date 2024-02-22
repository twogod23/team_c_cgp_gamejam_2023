using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    
    public GameObject targetobject;
    AudioSource audioSource;


    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale == 0)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;  // 時間停止
        pausePanel.SetActive(true);
        audioSource = targetobject.GetComponent<AudioSource>();
        audioSource.Pause();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;  // 再開
        pausePanel.SetActive(false);
        audioSource.UnPause();
    }
}