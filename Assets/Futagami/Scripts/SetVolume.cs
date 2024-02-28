using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    //BGMの音量
    public float bgmVolume;
    //SEの音量
    public float seVolume;

    // Start is called before the first frame update
    void Start()
    {
        //ここに音量の初期値を設定
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBGMVolume()
    {
        bgmVolume = bgmSlider.value;
    }

    public void SetSEVolume()
    {
        seVolume = seSlider.value;
    }
}
