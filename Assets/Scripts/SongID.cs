using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongID : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Modoru").GetComponent<Modoru>().GametoSel == true)
        {
            GameObject.Find("Modoru").GetComponent<Modoru>().GametoSel = false;
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
