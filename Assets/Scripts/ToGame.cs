using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unwelcome() {
        GameObject.Find("SongID").GetComponent<SongID>().ID = 1;
    }
    public void Ahoy()
    {
        GameObject.Find("SongID").GetComponent<SongID>().ID = 0;
    }

    public void Go()
    {
        SceneManager.LoadScene("Game");
    }
}
