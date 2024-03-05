using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startText.SetActive(false);
        }
    }
}
