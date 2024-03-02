using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeOut : MonoBehaviour//Stopはしません
{
    [SerializeField] private float fadeInDuration = 2.0f;
    [SerializeField] private float fadeOutDuration = 2.0f;
    [SerializeField] private AudioSource audioSource;
    private float maxVolume;

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }
    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()//消えてくやつ
    {
        float startVolume = audioSource.volume;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeOutDuration);
            audioSource.volume = Mathf.Lerp(startVolume, 0.0f, t);
            yield return null;
        }
    }
    public IEnumerator FadeIn()//だんだん音量が上がるやつ
    {
        float maxVolume = audioSource.volume;
        float startVolume = 0.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeInDuration);
            audioSource.volume = Mathf.Lerp(startVolume, maxVolume, t);
            yield return null;
        }
    }
}
