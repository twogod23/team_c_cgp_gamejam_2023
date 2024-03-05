using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    public static MenuSystem instance = null;
    public string songName;
    public string difficulty;
    public string sceneName;
    public float maxVolume;
    [SerializeField] AudioSource audioSource;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        maxVolume = audioSource.volume;
    }
    public void getMaxVolume()
    {
        maxVolume = audioSource.volume;
    }
}
//[HideInInspector]
