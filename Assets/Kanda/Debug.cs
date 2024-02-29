using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
    private ConfigCapture c;

    void Start(){
        GameObject obj = GameObject.Find("Cube");
        c = obj.GetComponent<ConfigCapture>();
    }

    public void ShowLog(){
        float a = c.NewestBGMVolume();
        float b = c.NewestSEVolume();
        UnityEngine.Debug.Log("BGM: " + a);
        UnityEngine.Debug.Log("SE: " + b);
    }

    public void SetData(){
        c.ConfigBGMVolumeCapture();
        c.ConfigSEVolumeCapture();
        UnityEngine.Debug.Log("DataSet Complete!");
    }
}
