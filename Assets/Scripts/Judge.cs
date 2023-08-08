using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Judge1 : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI Score;
    public AudioSource audioSource;
    public GameObject touch1;
    public GameObject touch2;
    public GameObject touch3;
    public GameObject touch4;

    public bool isone1 = false;
    public bool isone2 = false;
    public bool isone3 = false;
    public bool isone4 = false;
    void Update()
    {
        if (GManager.instance.Start)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    // Ray를 생성합니다.
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    // Ray가 어떤 오브젝트와 만났는지 확인합니다.
                    if (Physics.Raycast(ray, out hit))
                    {
                    // 만난 오브젝트가 큐브(레인)인 경우에만 처리합니다.
                        if (notesManager.LaneNum[0] == 0)
                        {
                        if (hit.transform == touch1.transform)
                        {
                            Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                        }

                        }
                        if (notesManager.LaneNum[0] == 1)
                        {
                            if (hit.transform == touch2.transform)
                            {
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                            }

                        }
                        if (notesManager.LaneNum[0] == 2)
                        {
                            if (hit.transform == touch3.transform)
                            {
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                            }

                        }
                        if (notesManager.LaneNum[0] == 3)
                        {
                            if (hit.transform == touch4.transform)
                            {
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                            }

                        }

                        if (notesManager.LaneNum[1] == 0)
                        {
                            if (hit.transform == touch1.transform)
                            {
                                isone1 = true;
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)));
                                isone1 = false;
                            }

                        }
                        if (notesManager.LaneNum[1] == 1)
                        {
                            if (hit.transform == touch2.transform)
                            {
                                isone2 = true;
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)));
                                isone2 = false;
                            }

                        }
                        if (notesManager.LaneNum[1] == 2)
                        {
                            if (hit.transform == touch3.transform)
                            {
                                isone3 = true;
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)));
                                isone3 = false;
                            }

                        }
                        if (notesManager.LaneNum[1] == 3)
                        {
                            if (hit.transform == touch4.transform)
                            {
                                isone4 = true;
                                Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)));
                                isone4 = false;
                            }

                        }
                    }
                }
            }
            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                message(3);
                deleteData();
                Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                Combo.text = GManager.instance.combo.ToString();
                //ミス
            }
        }
    }

    void Judgement(float timeLag)
    {
        if (timeLag <= 0.10)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            message(0);
            GManager.instance.perfect++;
            GManager.instance.combo++;
            GManager.instance.score += 300;
            Combo.text = GManager.instance.combo.ToString();
            Score.text = GManager.instance.score.ToString("D7");
            deleteData();
        }
        else
        {
            if (timeLag <= 0.15)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                Debug.Log("Great");
                message(1);
                GManager.instance.great++;
                GManager.instance.combo++;
                GManager.instance.score += 200;
                Combo.text = GManager.instance.combo.ToString();
                Score.text = GManager.instance.score.ToString("D7");
                deleteData();
            }
            else
            {
                if (timeLag <= 0.20)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    Debug.Log("Bad");
                    message(2);
                    GManager.instance.bad++;
                    GManager.instance.combo = 0;
                    GManager.instance.score += 50;
                    Combo.text = GManager.instance.combo.ToString();
                    Score.text = GManager.instance.score.ToString("D7");
                    deleteData();
                }
                
            }
        }
    }
    float GetABS(float num)//引数の絶対値を返す関数
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData()//すでにたたいたノーツを削除する関数
    {
        if (isone1 == true)
        {
            notesManager.NotesTime.RemoveAt(1);
            notesManager.LaneNum.RemoveAt(1);
            notesManager.NoteType.RemoveAt(1);
        }
        if (isone2 == true)
        {
            notesManager.NotesTime.RemoveAt(1);
            notesManager.LaneNum.RemoveAt(1);
            notesManager.NoteType.RemoveAt(1);
        }
        if (isone3 == true)
        {
            notesManager.NotesTime.RemoveAt(1);
            notesManager.LaneNum.RemoveAt(1);
            notesManager.NoteType.RemoveAt(1);
        }
        if (isone4 == true)
        {
            notesManager.NotesTime.RemoveAt(1);
            notesManager.LaneNum.RemoveAt(1);
            notesManager.NoteType.RemoveAt(1);
        }
        else
        {
            notesManager.NotesTime.RemoveAt(0);
            notesManager.LaneNum.RemoveAt(0);
            notesManager.NoteType.RemoveAt(0);
        }
    }

    void message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge]);
    }
}