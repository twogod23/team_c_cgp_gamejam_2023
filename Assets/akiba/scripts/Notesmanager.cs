using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data1
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Notes[] notes;
}

[Serializable]
public class Notes
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class Notesmanager : MonoBehaviour
{
    [SerializeField] private string songName; // Unity InspectorでsongNameを指定するためのシリアライズフィールド
    public int noteNum;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();

    [SerializeField] private float NotesSpeed;
    [SerializeField] private GameObject noteObj;

    void OnEnable()
    {
        noteNum = 0;
        Load(songName);
    }

    private void Load(string songName)
    {
        string inputString = Resources.Load<TextAsset>(songName).ToString();
        Data1 inputJson = JsonUtility.FromJson<Data1>(inputString);

        noteNum = inputJson.notes.Length;
        GManager.maxScore = noteNum * 5;//new



        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            float z = NotesTime[i] * NotesSpeed;
            float notePos = 0;

            if (inputJson.notes[i].block == 4)
            {
                notePos = 1.5f;
            }
            else
            {
                notePos = inputJson.notes[i].block;
            }
            GameObject instantiatedNote = Instantiate(noteObj, new Vector3(notePos - 1.5f, 0.55f, z), Quaternion.identity);

            if (inputJson.notes[i].block == 4)
            {
                instantiatedNote.transform.localScale = new Vector3(4f, 0.01f, 0.3f);
            }

            NotesObj.Add(instantiatedNote);
        }
    }
}