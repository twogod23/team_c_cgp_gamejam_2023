using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    public string nameSong;
    public GameObject AudioSourceObject;
    public float startTime;

    public void PlayMusic()
    {
        audioSource = AudioSourceObject.GetComponent<AudioSource>();
        audioClip = (AudioClip)Resources.Load("Musics/" + nameSong);//Musicsファイルを指定している。(Resources関係ない？)
        audioSource.clip = audioClip;
        audioSource.time = startTime;
        audioSource.Play();
    }
}
