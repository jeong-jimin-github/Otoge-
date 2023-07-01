using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void go()
    {
        SceneManager.LoadScene("Main");
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("go", 3);
    }
}
