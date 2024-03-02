using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNotes : MonoBehaviour
{
    //ノーツのスピードを設定
    float NoteSpeed;
    bool start;

    void Start()
    {
        NoteSpeed = GManager.noteSpeed;
    }
    void Update()
    {
        Transform myTransform = this.transform;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            start = true;
            
        }
        if (start)
        {
            Vector3 pos = myTransform.position;
            pos.z -= NoteSpeed * Time.deltaTime;
            transform.position = pos;
        }
    }
} 