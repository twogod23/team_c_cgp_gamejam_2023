using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    public string nameSong;
    public GameObject audio;

    public void PlayMusic()
    {
        audioSource = audio.GetComponent<AudioSource>();
        audioClip = (AudioClip)Resources.Load("Musics/" + nameSong);//Musicsファイルを指定している。(Resources関係ない？)
        audioSource.PlayOneShot(audioClip);
    }
}
