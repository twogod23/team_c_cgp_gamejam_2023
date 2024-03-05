using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance = null;
    [SerializeField] private Image fadePanel;
    [SerializeField] private float panelFadeDuration;

    public static FadeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<FadeManager>();
            }
            return instance;
        }
    }
    
    public IEnumerator FadeOut()
    {
        fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (elapsedTime < panelFadeDuration)
        {
            elapsedTime += Time.deltaTime; 
            float t = Mathf.Clamp01(elapsedTime / panelFadeDuration);
            fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     
        }
        fadePanel.color = endColor;
    }

    public static void StartFadeOut()//スタートボタンで読み込む
    {
        Instance.StartCoroutine(Instance.FadeOut());        
    }

    [SerializeField] private float soundFadeOutDuration;
    [SerializeField] private float soundFadeInDuration;
    [SerializeField] private AudioSource audioSource;
    
    public static void StartSoundFadeOut()
    {
        Instance.StartCoroutine(Instance.SoundFadeOut());
    }
    public static void StartSoundFadeIn()
    {
        Instance.StartCoroutine(Instance.SoundFadeIn());
    }

    public IEnumerator SoundFadeOut()//消えてくやつ
    {
        float startVolume = audioSource.volume;
        float elapsedTime = 0.0f;

        while (elapsedTime < soundFadeOutDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / soundFadeOutDuration);
            audioSource.volume = Mathf.Lerp(startVolume, 0.0f, t);
            yield return null;
        }
    }

    public IEnumerator SoundFadeIn()//だんだん音量が上がるやつ
    {
        float maxVolume = MenuSystem.instance.maxVolume;
        float startVolume = 0.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < soundFadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / soundFadeInDuration);
            audioSource.volume = Mathf.Lerp(startVolume, maxVolume, t);
            yield return null;
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
