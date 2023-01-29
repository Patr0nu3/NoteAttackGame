using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //public GameObject Enclosure;
    public GameObject Score;
    public GameObject Player;
    //public GameObject MusicStand;
    //public GameObject BadNote;
    // public GameObject GoodNote;
    //public GameObject Trumpet;
    //public GameObject GoodNoteSpawner;
    private int timeCounter;

    // Start: Called at the beginning of the gameplay
    void Start()
    {
        PlayerPrefs.SetInt("PlayerScore", 0);
        Instantiate(Score, Vector2.one, Quaternion.identity);
        Instantiate(Player, new Vector2(0f, -3.0f), Quaternion.identity);
        //Instantiate(MusicStand, Vector2.zero, Quaternion.identity);
        //Instantiate(BadNote, 2.0f * Vector2.up, Quaternion.identity);
        //Instantiate(Trumpet, new Vector2(8.0f, 3.0f), Quaternion.identity);
        timeCounter = 0;
    }

    // Update: Called once per frame
    void Update()
    {
        // GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = "Score:" + PlayerPrefs.GetInt("PlayerScore").ToString() + "%";
        /*
        if (Time.time > timeCounter)
        {
            GoodNoteSpawner.GetComponent<SpawnNotes>().spawnGoodNote((timeCounter % 5));
            timeCounter += 2;
        }
        */
    }
}
