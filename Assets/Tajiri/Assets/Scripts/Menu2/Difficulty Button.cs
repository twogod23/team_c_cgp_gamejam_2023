using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private Difficulty difficulty;
    private enum Difficulty{
        Easy,
        Normal,
        Hard,
    }
    
    public void OnClick()
    {
        MenuSystem.instance.difficulty = difficulty.ToString();
        ChangeColor();
        Animations();
        PlaySE();
    }
    [SerializeField] private Sprite coloredVer;
    Sprite whiteVer;
    Image targetImage;

    void ChangeColor()
    {
        GameObject[] difficultyButtons = GameObject.FindGameObjectsWithTag("DifficultyButton");
        foreach(GameObject btn in difficultyButtons)
        {
            DifficultyButton difficultyButton = btn.GetComponent<DifficultyButton>();
            difficultyButton.ResetColor();
        }
        targetImage.sprite = coloredVer;
    }

    void ResetColor()
    {
        targetImage.sprite = whiteVer;
    }

    void Animations()
    {
        Animation animation = gameObject.GetComponent<Animation>();
        animation.Play();
    }

    void Start()
    {
        targetImage = gameObject.GetComponent<Image>();
        whiteVer = targetImage.sprite;
    }
    void Update()
    {
        if(string.IsNullOrWhiteSpace(MenuSystem.instance.difficulty))
        {
            ResetColor();
        }
    }
    [SerializeField] private AudioClip buttonSE;
    [SerializeField] private AudioSource audioSourceSE;
    private void PlaySE()
    {
        audioSourceSE.PlayOneShot(buttonSE);
    }
}
