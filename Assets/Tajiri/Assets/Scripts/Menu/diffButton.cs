using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diffButton : MonoBehaviour
{
    public string SceneName;
    public string difficulty;
    public ButtonSceneChange playButton;
    public void changePlayButton()
    {
        playButton.sceneName = SceneName + "_" + difficulty;
    }
}
