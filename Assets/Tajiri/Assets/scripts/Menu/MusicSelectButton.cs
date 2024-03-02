using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicSelectButton : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public string newText; //曲名
    public Image targetImage;//画像
    public Sprite newSprite;//新
    public string SongName;//曲名
    public MusicPlay musicPlay;//曲saisei
    public GameObject AudioSourceObject;//オーディオソースオブジェクト
    AudioSource audioSource;

    public diffButton easyButton; //各難易度のボタンを更新するため
    public diffButton normalButton;
    public diffButton hardButton;
    public ButtonSceneChange buttonSceneChange;
    public DiffButtonAnimation diffButtonAnimation;//難易度ボタンのスライドアニメーション
    public DiffButtonAnimation songNameAnimation;//曲名のアニメーション(流用)
    public DiffButtonAnimation jacketAnimation;//ジャケットのアニメーション(流用)
    public ImageSwitcher imageSwitcherEasy;
    public ImageSwitcher imageSwitcherNormal;
    public ImageSwitcher imageSwitcherHard;

    [SerializeField] private PlayButton playButton;
    [SerializeField] private VariableMemory variableMemory;
    [Header("ここから再生(サビ)")] public float startTime;


    public void onClick()
    {
        buttonSceneChange.sceneName = null;
        changeText();
        changeImage();
        musicPlay.startTime = startTime;
        changeMusic();
        changeDiffButtons();
        imageSwitcherEasy.resetImage();
        imageSwitcherNormal.resetImage();
        imageSwitcherHard.resetImage();
        variableMemory.hasExecuted = false;
        playButton.ImageReset(); 
    }

    void changeText()
    {
        targetText.text = newText;
    }

    void changeImage()
    {
        targetImage.sprite = newSprite;
    }

    void changeDiffButtons()
    {
        easyButton.SceneName = SongName;
        normalButton.SceneName = SongName;
        hardButton.SceneName = SongName;
    }
    void changeMusic()
    {
        if(musicPlay.nameSong != SongName)
        {
            diffButtonAnimation.diffAnimation();//アニメーションもセットで
            songNameAnimation.diffAnimation();
            jacketAnimation.diffAnimation();
            audioSource = AudioSourceObject.GetComponent<AudioSource>();
            audioSource.Stop();
            musicPlay.nameSong = SongName;
            musicPlay.PlayMusic();
        }
    }
}

