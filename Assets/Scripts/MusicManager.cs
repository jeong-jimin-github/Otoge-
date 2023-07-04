using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioa;
    AudioClip Music;
    string songName;
    bool played;
    bool IsPause;
    void Start()
    {
        IsPause = false;
        GManager.instance.Start = false;
        songName = "Unwelcome School";
        audioa = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !played)
        {
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            played = true;
            audioa.PlayOneShot(Music);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*일시정지 활성화*/
            if (IsPause == false)
            {
                audioa.Pause();
                IsPause = true;
                return;
            }
 
            /*일시정지 비활성화*/
            if (IsPause == true)
            {
                audioa.UnPause();
                IsPause = false;
                return;
            }
        }
    }
}