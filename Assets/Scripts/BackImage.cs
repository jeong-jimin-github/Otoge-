using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackImage : MonoBehaviour
{
    public Image IMG;
    public Sprite Unwelcome;
    public Sprite Ahoy;
    // Start is called before the first frame update
    void Start()
    {
        if (Resources.LoadAll("Maps")[GameObject.Find("SongID").GetComponent<SongID>().ID].name == "Unwelcome School")
        {
            IMG.sprite = Unwelcome;
        }
        if (Resources.LoadAll("Maps")[GameObject.Find("SongID").GetComponent<SongID>().ID].name == "Ahoy!! 我ら宝鐘海賊団")
        {
            IMG.sprite = Ahoy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
