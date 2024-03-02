using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffButton : MonoBehaviour
{
    public string SceneName;
    public string difficulty;
    public FadeOutLoader fadeOutLoader;
    public void changePlayButton()
    {
        fadeOutLoader.sceneName = SceneName + "_" + difficulty;
    }
}
