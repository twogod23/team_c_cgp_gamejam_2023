using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndProgram : MonoBehaviour
{
    void Update()
    {
        //Escキーを押した際
        if (Input.GetKey(KeyCode.Escape))
        {
            //プログラムを終了
            Application.Quit();
        }
    }
}