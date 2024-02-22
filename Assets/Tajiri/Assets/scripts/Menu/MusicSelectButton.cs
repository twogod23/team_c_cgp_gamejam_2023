using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlectButton : MonoBehaviour
{
    public TextMesh targetText;
    public string newText;

    public Image targetImage;

    public Sprite newSprite;

    void onClick()
    {
        changeText();

    }
    void changeText()
    {
        targetText.text = newText;
    }

    void changePicture()
    {
        targetImage.sprite = newSprite;
    }
}
