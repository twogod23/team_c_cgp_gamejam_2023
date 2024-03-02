using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    [SerializeField] private Sprite newSprite;
    [SerializeField] private Sprite firstSprite;
    
    //難易度選択ボタンのために
    [SerializeField] private ImageSwitcher imageSwitcher1;
    [SerializeField] private ImageSwitcher imageSwitcher2;
    public VariableMemory variableMemory;//難易度が選択されているかbool
    public void resetImage()//曲選択時に実行
    {
        targetImage.sprite = firstSprite;
        variableMemory.isDiffSelected = false;
    }
        
    public void setImage()//難易度選択時に実行
    {
        targetImage.sprite = newSprite;
        imageSwitcher1.resetImage();
        imageSwitcher2.resetImage();
        variableMemory.isDiffSelected = true;
    }

}
