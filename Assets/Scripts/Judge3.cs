using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Judge3 : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI Score;
    public AudioSource audioSource;
    public bool isOK;
    public GameObject on;

    private void Start()
    {
        isOK = false;
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        isOK = true;
        on = other.gameObject;
    }

    private void OnTriggerExit(UnityEngine.Collider other)
    {
        isOK = false;
    }

    void Update()
    {
        if (GManager.instance.Start)
        {

            if (Input.GetKeyDown(KeyCode.K))//〇キーが押されたとき
            {
                if (isOK == true)
                {
                    if (Vector3.Distance(gameObject.transform.position, on.transform.position) < 1)
                    {
                        Debug.Log("OK");
                        message(0);
                        GManager.instance.perfect++;
                        GManager.instance.combo++;
                        GManager.instance.score += 300;
                        Combo.text = GManager.instance.combo.ToString();
                        Score.text = GManager.instance.score.ToString("D7");
                        Destroy(on);
                    }
                    else if (Vector3.Distance(gameObject.transform.position, on.transform.position) < 1.5)
                    {
                        Debug.Log("OK");
                        message(1);
                        GManager.instance.perfect++;
                        GManager.instance.combo++;
                        GManager.instance.score += 300;
                        Combo.text = GManager.instance.combo.ToString();
                        Score.text = GManager.instance.score.ToString("D7");
                        Destroy(on);
                    }
                    else if (Vector3.Distance(gameObject.transform.position, on.transform.position) < 2)
                    {
                        Debug.Log("OK");
                        message(2);
                        GManager.instance.perfect++;
                        GManager.instance.combo++;
                        GManager.instance.score += 300;
                        Combo.text = GManager.instance.combo.ToString();
                        Score.text = GManager.instance.score.ToString("D7");
                        Destroy(on);
                    }
                }
            }
        }
    }


    void deleteData()//すでにたたいたノーツを削除する関数
    {
        notesManager.NotesTime.RemoveAt(0);
        notesManager.LaneNum.RemoveAt(0);
        notesManager.NoteType.RemoveAt(0);
    }

    void message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge]);
    }
}