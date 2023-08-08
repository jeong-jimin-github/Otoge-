using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    //ノーツのスピードを設定
    int NoteSpeed = 15;
    bool start;

    private void Start()
    {
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            start = true;
        }
        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
        }
    }
}