using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数
    public TextMeshProUGUI Combo;
    public TextMeshProUGUI Score;
    public AudioSource audioSource;
    void Update()
    {
        if (GManager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))//〇キーが押されたとき
            {
                audioSource.Play();
                if (notesManager.LaneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                    /*
                    本来ノーツをたたく場所と実際にたたいた場所がどれくらいずれているかを求め、
                    その絶対値をJudgement関数に送る
                    */
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.Play();
                if (notesManager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                audioSource.Play();
                if (notesManager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                audioSource.Play();
                if (notesManager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)));
                }
            }

            if (Time.time > notesManager.NotesTime[0] + 0.1f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                deleteData();
                message(3);
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                Combo.text = GManager.instance.combo.ToString();
                //ミス
            }
        }
    }
    void Judgement(float timeLag)
    {
        if (timeLag <= 0.06)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            deleteData();
            message(0);
            GManager.instance.perfect++;
            GManager.instance.combo++;
            GManager.instance.score += 300;
            Combo.text = GManager.instance.combo.ToString();
            Score.text = GManager.instance.score.ToString("D7");
        }
        else
        {
            if (timeLag <= 0.08)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                deleteData();
                message(1);
                GManager.instance.great++;
                GManager.instance.combo++;
                GManager.instance.score += 200;
                Combo.text = GManager.instance.combo.ToString();
                Score.text = GManager.instance.score.ToString("D7");
            }
            else
            {
                if (timeLag <= 0.1)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    deleteData();
                    message(2);
                    GManager.instance.bad++;
                    GManager.instance.combo = 0;
                    GManager.instance.score += 50;
                    Combo.text = GManager.instance.combo.ToString();
                    Score.text = GManager.instance.score.ToString("D7");
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
        notesManager.NotesTime.RemoveAt(0);
        notesManager.LaneNum.RemoveAt(0);
        notesManager.NoteType.RemoveAt(0);
        notesManager.NotesObj.RemoveAt(0);
    }

    void message(int judge)//判定を表示する
    {
        Instantiate(MessageObj[judge]);
    }
}