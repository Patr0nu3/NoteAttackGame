using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicAreaSpawn : MonoBehaviour
{
    public GameObject area;
    public GameObject[] pos = new GameObject[3];

    private bool exist;
    private float cd;

    void Start()
    {
        exist = false;
        cd = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        int r = (int) Random.Range(0, 20);
        // if (r == 10 && !exist) {spawnArea();}
        if (!exist) {spawnArea();}
        if (exist) {cd -= Time.deltaTime;}
        if (cd < 0) {
            exist = false;
            cd = 15f;
        }
    }

    void spawnArea()
    {
        exist = true;
        int index = Random.Range(0, 2);
        Instantiate(area, pos[index].transform);
    }
}
