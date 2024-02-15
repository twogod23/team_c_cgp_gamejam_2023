using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    public int gameHP = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hpText.text = "HP  " + gameHP;
    }
}
