using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class fast : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update

    void Set()
    {
         textMeshProUGUI.text = File.ReadAllText(Application.streamingAssetsPath + "/Config/Config.txt");
    }

    public void WriteData(string strData)
    {
        // FileMode.Create´Â µ¤¾î¾²±â.
        FileStream f = new FileStream(Application.streamingAssetsPath + "/Config/Config.txt", FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.WriteLine(strData);
        writer.Close();
    }

    void Start()
    {
        Set();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            textMeshProUGUI.text = (Int32.Parse(textMeshProUGUI.text) - 1).ToString();

            WriteData(textMeshProUGUI.text);
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            textMeshProUGUI.text = (Int32.Parse(textMeshProUGUI.text) + 1).ToString();


            WriteData(textMeshProUGUI.text);
        }
        if (GameObject.Find("Modoru").GetComponent<Modoru>().GametoSel == true)
        {
            Set();
            GameObject.Find("Modoru").GetComponent<Modoru>().GametoSel = false;
        }
    }
}
