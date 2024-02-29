using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDebugLog : MonoBehaviour
{
    private ConfigCapture c;

    void Start(){
        GameObject obj = GameObject.Find("Cube");
        c = obj.GetComponent<ConfigCapture>();
    }

    public void ShowLog(){
        float a = c.NewestBGMVolume();
        float b = c.NewestSEVolume();
        Debug.Log("BGM: " + a);
        Debug.Log("SE: " + b);
    }

    public void SetData(){
        c.ConfigBGMVolumeCapture();
        c.ConfigSEVolumeCapture();
        Debug.Log("DataSet Complete!");
    }
}
