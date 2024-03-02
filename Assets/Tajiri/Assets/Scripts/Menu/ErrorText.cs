using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorText : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public float displayTime = 2f;
    public void errorDisplay(string Text)
    {
        targetText.text = Text;
        targetText.gameObject.SetActive(true);
        Invoke("hideText",displayTime);
    }
    
    void hideText()
    {
        targetText.gameObject.SetActive(false);
    }
    void Start()
    {
        targetText.gameObject.SetActive(false);
    }
}
