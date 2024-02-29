using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        //ポーズメニュー作成後にコメントアウトを消す
        //pausePanel.SetActive(false);
    }
    public void Select()
    {
        //ポーズメニュー作成後にコメントアウトを消す
        //pausePanel.SetActive(true);
        Debug.Log("PauseButtonPushed");
    }
}
