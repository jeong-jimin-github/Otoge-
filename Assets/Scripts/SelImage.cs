using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelImage : MonoBehaviour
{
    public Image Image;
    public Sprite Unwelcome;
    public Sprite UN;
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
            Image.sprite = UN;
        }
        if (kyoku == 1)
        {
            Image.sprite = Unwelcome;
        }
    }
}
