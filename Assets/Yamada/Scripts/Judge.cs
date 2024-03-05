using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] Notesmanager notesmanager;//スクリプト「notesmanager」を入れる変数

    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject finish;//new

    AudioSource audio;
    [SerializeField] AudioClip hitSound;

    float endTime = 0;//new

    void Start()
    {
        audio = GetComponent<AudioSource>();
        endTime = notesmanager.NotesTime[notesmanager.NotesTime.Count-1];//new
    }
    void Update()
    {
        if (GManager.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))//〇キーが押されたとき
            {
                if (notesmanager.LaneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesmanager.NotesTime[0] + GManager.StartTime)), 0);
                }
                else
                {
                    if (notesmanager.LaneNum[1] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesmanager.NotesTime[1] + GManager.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (notesmanager.LaneNum[0] == 1)
                {
                    Judgement(GetABS(Time.time - (notesmanager.NotesTime[0] + GManager.StartTime)),0);
                }
                else
                {
                    if (notesmanager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesmanager.NotesTime[1] + GManager.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (notesmanager.LaneNum[0] == 2)
                {
                    Judgement(GetABS(Time.time - (notesmanager.NotesTime[0] + GManager.StartTime)),0);
                }
                else
                {
                    if (notesmanager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesmanager.NotesTime[1] + GManager.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (notesmanager.LaneNum[0] == 3)
                {
                    Judgement(GetABS(Time.time - (notesmanager.NotesTime[0] + GManager.StartTime)),0);
                }
                else
                {
                    if (notesmanager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesmanager.NotesTime[1] + GManager.StartTime)), 1);
                    }
                }
            }

            if (Time.time > endTime + GManager.StartTime)
            {
                finish.SetActive(true);
                Invoke("ResultScene", 3f);
                return;
            }

            if (Time.time > notesmanager.NotesTime[0] + 0.2f +GManager.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                GManager.miss++;
                GManager.combo = 0;
                //ミス
            }
        }
    }
    void Judgement(float timeLag,int numOffset)
    {
        audio.PlayOneShot(hitSound);
        if (timeLag <= 0.05)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            message(0);
            GManager.ratioScore += 5;//new!!
            GManager.perfect++;
            GManager.combo++;
            deleteData(numOffset);
        }
        else
        {
            if (timeLag <= 0.08)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                Debug.Log("Great");
                message(1);
                GManager.ratioScore += 3;//new!!
                GManager.great++;
                GManager.combo++;
                deleteData(numOffset);
            }
            else
            {
                if (timeLag <= 0.10)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    Debug.Log("Bad");
                    message(2);
                    GManager.ratioScore += 1;//new!!
                    GManager.bad++;
                    GManager.combo = 0;
                    deleteData(numOffset);
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
    void deleteData(int numOffset)//すでにたたいたノーツを削除する関数
    {
        notesmanager.NotesTime.RemoveAt(numOffset);
        notesmanager.LaneNum.RemoveAt(numOffset);
        notesmanager.NoteType.RemoveAt(numOffset);
        GManager.score = (int)Math.Round(1000000 * Math.Floor(GManager.ratioScore / GManager.maxScore * 1000000) / 1000000);
        //↑new!!
        //comboText.text = GManager.combo.ToString();//new!!
        //scoreText.text = GManager.score.ToString();//new!!   
    }

    void message(int judge)//判定を表示する
    {
        float pos;

        if (notesmanager.LaneNum[0] == 4)
        {
            pos = 1.5f;
        }
        else
        {
            pos = notesmanager.LaneNum[0];
        }
        Instantiate(MessageObj[judge],new Vector3(pos-1.5f,0.76f,0.15f),Quaternion.Euler(45,0,0));
    }

    void ResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}