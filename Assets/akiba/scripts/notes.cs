using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    int NoteSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
    }
}
