using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;
    bool IsPause;
 
    // Use this for initialization
    void Start () {
        PauseUI.SetActive(false);
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*일시정지 활성화*/
            if (IsPause == false)
            {
                Time.timeScale = 0;
                PauseUI.SetActive(true);
                IsPause = true;
                return;
            }
 
            /*일시정지 비활성화*/
            if (IsPause == true)
            {
                Time.timeScale = 1;
                PauseUI.SetActive(false);
                IsPause = false;
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                SceneManager.LoadScene("Select");
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                SceneManager.LoadScene("Game");
            }
        }

    }
}
