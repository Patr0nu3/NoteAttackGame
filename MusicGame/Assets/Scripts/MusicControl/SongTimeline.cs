using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SongTimeline : MonoBehaviour
{
    public float songTime; /* total time of song input from outside */
    public bool timeRunning;
    private float playTime;

    public GameObject GoodNotes;
    public GameObject BadNotes;

    void Start()
    {
        /* convert songTime from min.sec = sec */
        float diff = songTime - (int) songTime;

        if (diff > 0) {
            while (diff - (int) diff > 0) {
                diff *= 10;
            }
        }

        songTime = 60 * (int) songTime + diff;

        /* set value */
        timeRunning = true;
        playTime = 0;
        if (songTime < 0) { timeRunning = false; }
    }

    void Update()
    {
        if (timeRunning) {
            /* count time */
            playTime += Time.deltaTime;

            if (playTime >= songTime) {
                timeRunning = false; /* time runs out */
            } else {
                /* call helper function to spawn notes */
                spawnNotes(playTime);
            }

        }
    }

    void checkNote(float playTime)
    {
        // check if this time is in the time line list
        // if so
        spawnNotes(playTime);
    }

    void spawnNotes(float playTime)
    {
        GameObject note;
        if (true /* change to good or bad */) {
            note = GoodNotes;
        } else {
            note = BadNotes;
        }

        Instantiate(note, Vector3.zero, Quaternion.identity);
    }
}
