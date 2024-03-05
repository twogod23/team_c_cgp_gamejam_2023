using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audio;
    [SerializeField] private AudioClip Music;
    string songName;
    bool played;
    void Start()
    {
        GManager.Start = false;
        songName = "kiminojuusei_mixed";
        audio = GetComponent<AudioSource>();
        //Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)&&!played)
        {
            GManager.Start = true;
            GManager.StartTime = Time.time;
            played = true;
            audio.PlayOneShot(Music);
        }
    }
}