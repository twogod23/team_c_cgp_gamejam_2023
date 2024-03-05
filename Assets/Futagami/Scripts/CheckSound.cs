using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSound : MonoBehaviour
{
    [SerializeField] private GameObject Director;
    private ConfigCapture conCap;
    private float bgmVolume;
    // Start is called before the first frame update
    void Start()
    {
        conCap = Director.GetComponent<ConfigCapture>();
        bgmVolume = conCap.NewestBGMVolume();
        Debug.Log("BGMVolume: " + bgmVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
