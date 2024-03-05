using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControler : MonoBehaviour
{
    [SerializeField] private GameObject bgmObject;
    private AudioSource bgmSource;
    [SerializeField] private GameObject seObject;
    private AudioSource seSource;
    //ConfigCaptureのスクリプトを取得
    [SerializeField] private GameObject Director;
    private ConfigCapture conCap;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource = bgmObject.GetComponent<AudioSource>();
        seSource = seObject.GetComponent<AudioSource>();
        //ここに音量の初期値を設定
        conCap = Director.GetComponent<ConfigCapture>();
        SetBGMVolume();
        SetSEVolume();
    }

    public void SetBGMVolume()
    {
        bgmSource.volume = conCap.NewestBGMVolume();
    }

    public void SetSEVolume()
    {
        seSource.volume = conCap.NewestSEVolume();
    }
}
