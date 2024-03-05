using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongButton : MonoBehaviour
{
    [SerializeField] private string songName;
    [SerializeField] private bool firstPlaySong;
    [SerializeField] private GameObject[] animatedGameObject;
    [SerializeField] private Image jacket;
    [SerializeField] private Sprite songSprite;
    [SerializeField] private TextMeshProUGUI songText;
    [SerializeField] private string songNameJP;

    public void OnClick()
    {
        PlaySE();
        if(MenuSystem.instance.songName != this.songName)
        {
            MusicPlay();
            SetSongName();
            StopAnimations();
            Animations();
        }
    }
    void SetSongName()
    {
        MenuSystem.instance.difficulty = null;
        MenuSystem.instance.sceneName = null;
        MenuSystem.instance.songName = songName;
        songText.text = songNameJP;
        jacket.sprite = songSprite;
    }
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int startTime;
    void MusicPlay()
    {
        audioSource.Stop();
        audioSource.clip = (AudioClip)Resources.Load("Musics/" + songName);
        audioSource.time = startTime;
        audioSource.Play();
        FadeManager.StartSoundFadeIn();
    }

    void Animations()
    {
        foreach(GameObject aGB in animatedGameObject)
        {
            Animation animation = aGB.gameObject.GetComponent<Animation>();
            if(animation != null)
            {
                animation.Play();
            }
        }
    }
    void StopAnimations()
    {
        foreach(GameObject aGB in animatedGameObject)
        {
            Animation animation = aGB.gameObject.GetComponent<Animation>();
            if(animation != null)
            {
                animation.Stop();
            }
        }
    }

    [SerializeField] private AudioClip buttonSE;
    [SerializeField] private AudioSource audioSourceSE;
    private void PlaySE()
    {
        audioSourceSE.PlayOneShot(buttonSE);
    }

    void Start()
    {
        if(firstPlaySong)
        {
            MenuSystem.instance.songName = this.songName;
            MusicPlay();
            SetSongName();
            StopAnimations();
            Animations();
        }
    }
}
