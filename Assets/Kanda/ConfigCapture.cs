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
        return PlayerPrefs.GetFloat("BGMVolume");
    }

    public float NewestSEVolume()
    {
        return PlayerPrefs.GetFloat("SEVolume");
    }
}
