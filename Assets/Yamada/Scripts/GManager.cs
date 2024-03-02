using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public static float maxScore = 0;//new!!
    public static float ratioScore = 0;//new!!

    public static int songID = 0;
    public static float noteSpeed = 8.0f;

    public static bool Start = true;
    public static float StartTime = 0f;

    public static int combo = 0;
    public static int score = 0;

    public static int perfect = 0;
    public static int great = 0;
    public static int bad = 0;
    public static int miss = 0;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
