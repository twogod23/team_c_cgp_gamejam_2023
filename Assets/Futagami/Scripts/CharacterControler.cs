using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControler : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    private Image CharacterImage;
    [SerializeField] private Sprite CharacterNormalImage;
    [SerializeField] private Sprite CharacterComboImage;
    [SerializeField] private Sprite CharacterMissImage;
    private int miss = 0;
    private int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        CharacterImage = Character.GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GManager.combo > 3)
        {
            CharacterImage.sprite = CharacterComboImage;
        }
        else if (counter > 10)
        {
            CharacterImage.sprite = CharacterMissImage;
        }
        else
        {
            CharacterImage.sprite = CharacterNormalImage;
        }

        if (GManager.combo > 0)
        {
            counter = 0;
        }

        if (GManager.miss > miss)
        {
            counter++;
            miss = GManager.miss;
        }
    }
}
