using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicSelectButton : MonoBehaviour
{
    public TextMeshProUGUI targetText;//テキストメッシュプロにはこれが必要
    public string newText; //曲名を表示
    public Image targetImage;//ターゲットとなる画像。これの中身を変える
    public Sprite newSprite;//新しい中身
    public string SongName;//曲名
    public MusicPlay musicPlay;//曲を流すスクリプトへアクセス
    public GameObject targetObject;//オーディオソースオブジェクト
    AudioSource audioSource;

    public PlayButton easyButton; //各難易度のボタンを更新するため
    public PlayButton normalButton;
    public PlayButton hardButton;



    public void onClick()
    {
        changeText();
        changeImage();
        changeMusic();
        changeDiffButtons();
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
            audioSource = targetObject.GetComponent<AudioSource>();
            audioSource.Stop();
            musicPlay.nameSong = SongName;
            musicPlay.PlayMusic();
        }
    }

}

