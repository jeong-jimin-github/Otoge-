using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToSel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void gotosel()
    {
        SceneManager.LoadScene("Select");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Invoke("gotosel", 1);
        }
    }
}
