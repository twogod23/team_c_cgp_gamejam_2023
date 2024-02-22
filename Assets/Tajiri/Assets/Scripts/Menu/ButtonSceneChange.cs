using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneChange : MonoBehaviour
{
    public string SceneName;
    public SceneChanger sceneChanger;
    public void ButtonClick()
    {
        sceneChanger.ChangeScene(SceneName);
    }
}

