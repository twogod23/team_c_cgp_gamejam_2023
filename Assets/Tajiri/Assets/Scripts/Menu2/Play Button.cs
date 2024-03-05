using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton: MonoBehaviour
{
    private Image playButton;
    private Sprite whiteVer;
    [SerializeField] private Sprite coloredVer;
    [SerializeField] private float delaySeconds = 3f;
    
    public void OnClick()
    {
        if(!string.IsNullOrWhiteSpace(MenuSystem.instance.songName) && !string.IsNullOrWhiteSpace(MenuSystem.instance.difficulty))
        {
            SetSceneName();
            PlaySE(buttonSE);
            FadeManager.StartFadeOut();
            FadeManager.StartSoundFadeOut();
            Invoke("SceneChanger",delaySeconds);
        }
        else
        {
            PlaySE(buttonSE2);
            Debug.Log("曲、または難易度が選択されていません");
        }
    }
    private void SetSceneName()
    {     
        MenuSystem.instance.sceneName = MenuSystem.instance.songName + "_" + MenuSystem.instance.difficulty;    
    }
    private void SceneChanger()
    {
        SceneManager.LoadScene(MenuSystem.instance.sceneName);
    }
    [SerializeField] private AudioClip buttonSE;
    [SerializeField] private AudioClip buttonSE2;
    [SerializeField] private AudioSource audioSourceSE;
    private void PlaySE(AudioClip SE)
    {
        audioSourceSE.PlayOneShot(SE);
    }

    void Start()
    {
        playButton = gameObject.GetComponent<Image>();
        whiteVer = playButton.sprite;
    }
    void Update()
    {
        if(!string.IsNullOrWhiteSpace(MenuSystem.instance.songName) && !string.IsNullOrWhiteSpace(MenuSystem.instance.difficulty))
        {
            playButton.sprite = coloredVer;
        }
        else
        {
            playButton.sprite = whiteVer;
        }
    }
    
}
