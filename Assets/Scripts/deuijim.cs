using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class deuijim : MonoBehaviour
{

    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    { 
        GManager.instance.combo = 0;
        Combo.text = GManager.instance.combo.ToString();
        Instantiate(MessageObj[3]);
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
