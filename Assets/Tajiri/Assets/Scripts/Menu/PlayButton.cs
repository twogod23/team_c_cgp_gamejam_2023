using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public string SceneName;
    public string difficulty;
    public SceneChanger sceneChanger;
    
    public void PlayButtonClick()
    {
        sceneChanger.ChangeScene(SceneName + "_" + difficulty);
    }
}
