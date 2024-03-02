using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiffButtonAnimation : MonoBehaviour
{
    public GameObject diffButtons;
    public Animation slideAnimation;
    public string animationName;
    public void diffAnimation()
    {
        slideAnimation[animationName].time = 0;
        slideAnimation.Play();
    }
}
