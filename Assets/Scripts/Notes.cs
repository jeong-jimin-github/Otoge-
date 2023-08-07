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
        string co = Resources.Load<TextAsset>("Config/Config").ToString();
        NoteSpeed = Int32.Parse(co);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
        }
    }
}