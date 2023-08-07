using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelMusic : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip Ahoy;
    public AudioClip Unswelcome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int kyoku = GameObject.Find("SongID").GetComponent<SongID>().ID;
        if (kyoku == 0)
        {
            AS.clip = Ahoy;
        }
        if (kyoku == 1)
        {
            AS.clip = Unswelcome;
        }
        if (!AS.isPlaying)
        {
            AS.Play();
        }
    }
}
