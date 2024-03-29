using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOption : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private List<GameObject> hideObjects;
    
    //ConfigCaptureのスクリプトを取得
    [SerializeField] private GameObject Director;
    private ConfigCapture conCap;
    private VolumeControler volumeControler;
    private SetVolume setVolume;

    // Start is called before the first frame update
    void Start()
    {
        conCap = Director.GetComponent<ConfigCapture>();
        volumeControler = Director.GetComponent<VolumeControler>();
        setVolume = Director.GetComponent<SetVolume>();

        optionPanel.SetActive(false);
        foreach (var obj in hideObjects)
        {
            obj.SetActive(true);
        }
    }

    public void DisplayOptionPanel()
    {
        optionPanel.SetActive(true);
        if (hideObjects != null)
        {
            foreach (var obj in hideObjects)
            {
                obj.SetActive(false);
            }
        }
        setVolume.EnterBGMVolume();
        setVolume.EnterSEVolume();
    }

    public void CloseOptionPanel()
    {
        //音量の設定を保存
        conCap.ConfigBGMVolumeCapture();
        conCap.ConfigSEVolumeCapture();
        optionPanel.SetActive(false);
        if (hideObjects != null)
        {
            foreach (var obj in hideObjects)
            {
                obj.SetActive(true);
            }
        }
        volumeControler.SetBGMVolume();
        volumeControler.SetSEVolume();
    }
}
