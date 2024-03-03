using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOutLoader : MonoBehaviour//音楽もフェードアウトさせてロードシーン的なこともしたい
{
    [SerializeField] private Image fadePanel;
    [SerializeField] float fadeDuration;
    [SerializeField] private SceneChanger sceneChanger;
    [SerializeField] private ErrorText errorText;
    public string sceneName;//曲選択→難易度選択
    [SerializeField] [Header("エラー文")] string errormessage;
    [SerializeField] MusicFadeOut musicFadeOut;

    public IEnumerator FadeOut()
    {
        fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime; 
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  
            fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     
        }
        fadePanel.color = endColor;
        sceneChanger.Invoke("ChangeScene",2.0f);
    }

    public void startFadeOut()//スタートボタンで読み込む
    {
        if(!string.IsNullOrWhiteSpace(sceneName))
        {
            StartCoroutine(FadeOut());
            musicFadeOut.StartFadeOut();
        }
        else
        {
            errorText.errorDisplay(errormessage);
        }
    }
        
}
