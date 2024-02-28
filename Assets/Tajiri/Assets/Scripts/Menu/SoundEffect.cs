using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject AudioSourceObject;
    AudioSource audioSource;
    public void PlaySE()
    {
        audioSource = AudioSourceObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }
}
