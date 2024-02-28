using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneChange : MonoBehaviour
{
    public string sceneName;
    public SceneChanger sceneChanger;
    [SerializeField] [Header("エラーテキスト")] private string errormessage;
    public ErrorText errorText;
    public void ButtonClick()
    {
        if(!string.IsNullOrWhiteSpace(sceneName))
        {
            sceneChanger.ChangeScene(sceneName);
        }
        else
        {
            errorText.errorDisplay(errormessage);
        }
    }
}

