using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entertoANi : MonoBehaviour
{
    List<string> animArray;
    public Animation ani;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        animArray = new List<string>();
        AnimationArray();
        ani.Play(animArray[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))//〇キーが押されたとき
        {
            ani.Play(animArray[2]);
        }
    }
    public void AnimationArray()
    {
        foreach (AnimationState state in ani)
        {
            animArray.Add(state.name);
            index++;
        }
    }
}
