using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AnimateTitleStartText : MonoBehaviour
{
    //テキストのアニメーションスピードを調整
    [SerializeField] private float textColorScale = 1.2f;
    //テキストの色の透明度を変更するための変数
    private float textColor = 0.0f;
    //テキストを指定
    [SerializeField] private TextMeshProUGUI informationTMP;
    //経過時間の保持
    private float time = 0.0f;
    //遷移先のシーンの指定
    [SerializeField] private string nextSceneName;

    //設定ボタンの指定
    [SerializeField] private GameObject optionButton;
    private float timer = 0.0f;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間を加算
        time += Time.deltaTime;
        
        //文字のアニメーション
        //文字色の変更スピードを指定
        textColor = Mathf.Abs(Mathf.Sin(time * textColorScale));
        //文字色を変更
        informationTMP.color = new Color(1.0f, 1.0f, 1.0f, textColor);

        //シーン遷移
        //スペースキーが押されるまたはマウスのキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Select();
        }

        if (informationTMP.enabled == false)
        {
            timer += Time.deltaTime / 2;
            fadePanel.GetComponent<Image>().color = new Color(0, 0, 0, timer);
            if (timer >= 1.0f)
            {
                //ゲームシーンに移動
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    //シーン遷移の挙動
    public void Select()
    {
        //テキストの非表示
        informationTMP.enabled = false;
        //設定ボタンの非表示
        optionButton.SetActive(false);
        //フェードパネルの表示
        fadePanel.SetActive(true);
        //音楽の再生
        audioSource.PlayOneShot(audioClip);
    }
}
