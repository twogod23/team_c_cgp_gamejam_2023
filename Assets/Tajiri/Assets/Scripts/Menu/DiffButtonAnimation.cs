using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffButtonAnimation : MonoBehaviour
{
    public GameObject diffButtons;
    public Animation animation;
    public void diffAnimation()
    {
        animation.Play();
    }
}
