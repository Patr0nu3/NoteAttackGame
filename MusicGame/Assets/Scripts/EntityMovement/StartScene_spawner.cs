using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene_spawner : MonoBehaviour
{
    public GameObject spawner;
    private float timeCounter;

    void start()
    {
        timeCounter = 0;
    }

    void Update()
    {
            if (Time.time > timeCounter)
            {
                spawner.GetComponent<SpawnNotes>().spawnNote();
                timeCounter += 0.03f;
            }
    }
}
