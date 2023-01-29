using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Song", menuName = "Song Notes")]
public class SongNoteType : ScriptableObject
{
    public struct Note
    {
        public float spawnTime;
        public bool isGood;

        /* expecting that a single int key to assign position and path */
        public int givenPosition;
        public int givenPath;
    }

    public List<Note> noteList = new List<Note>();
    public List<string> words = new List<string>();
    public string songName;

    void Start()
    {
        foreach (string line in words) {
            Note newNote = new Note();
            string[] parse = line.Split(';');
            newNote.spawnTime = float.Parse(parse[0]);

            if (parse[1] == " good") {
                newNote.isGood = true;
            } else if (parse[1] == " bad") {
                newNote.isGood = false;
            }

            newNote.givenPosition = int.Parse(parse[2]);
            newNote.givenPath = int.Parse(parse[3]);

            noteList.Add(newNote);
        }
    }
}
