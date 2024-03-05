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
    
    public GameObject audiotargetobject;
    public TextMeshProUGUI CountText;
    AudioSource audioSource;
    float delay = 1.0f;


    void Start()
    {
        CountText.gameObject.SetActive(false);
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeButtonClick); 
        audioSource = audiotargetobject.GetComponent<AudioSource>();
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
        for (int i = 3; i > 0; i--)
        {
            if (pausePanel.activeSelf == true)
            {
                yield break;
            }
            CountText.text = i.ToString();
            yield return new WaitForSecondsRealtime(delay);
        }
        CountText.gameObject.SetActive(false);
        ResumeGame();
    }
}