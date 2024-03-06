using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigCapture : MonoBehaviour
{
    private SetVolume setVolume;
    void Start()
    {
        setVolume = GetComponent<SetVolume>();
    }

    public void ConfigBGMVolumeCapture()
    {
        setVolume.SetBGMVolume();
        PlayerPrefs.SetFloat("BGMVolume", setVolume.bgmVolume);
        PlayerPrefs.Save();
    }

    public void ConfigSEVolumeCapture()
    {
        setVolume.SetSEVolume();
        PlayerPrefs.SetFloat("SEVolume", setVolume.seVolume);
        PlayerPrefs.Save();
    }

    public float NewestBGMVolume()
    {
        Debug.Log("readBGM" + PlayerPrefs.GetFloat("BGMVolume"));
        return PlayerPrefs.GetFloat("BGMVolume", 0.5f);
    }

    public float NewestSEVolume()
    {
        Debug.Log("readSE" + PlayerPrefs.GetFloat("SEVolume"));
        return PlayerPrefs.GetFloat("SEVolume", 0.5f);
    }
}
