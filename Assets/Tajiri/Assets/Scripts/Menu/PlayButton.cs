using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private VariableMemory variableMemory;
    void Update()
    {
        if
        (
            variableMemory.isDiffSelected && !variableMemory.hasExecuted
        )
        {
            ImageSwitch();
            variableMemory.hasExecuted = true;
        }
    }

    [SerializeField] private Image targetImage;
    [SerializeField] private Sprite newSprite;
    [SerializeField] private Sprite firstSprite;
    public void ImageSwitch()//冗長
    {
        targetImage.sprite = newSprite;
    }
    public void ImageReset()
    {
        targetImage.sprite = firstSprite;
        variableMemory.hasExecuted = false;
    }
}
