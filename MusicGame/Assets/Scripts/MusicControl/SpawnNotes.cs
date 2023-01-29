using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotes : MonoBehaviour
{
    public GameObject GoodNote;
    public GameObject BadNote;
    public GameObject Note;
    public GameObject Trumpet;
    public GameObject Drum;
    public GameObject Violin;
    public GameObject[] pos = new GameObject[7];

    public void spawnNote() {
        int r = Random.Range(0, 18);
        int index = Random.Range(0, 7);
        if (r < 3) {
            Instantiate(GoodNote, pos[index].transform);
        } else if (r < 6) {
            Instantiate(BadNote, pos[index].transform);
        } else if (r < 9){
            Instantiate(Note, pos[index].transform);
        } else if (r < 12) {
            Instantiate(Trumpet, pos[index].transform);
        } else if (r < 15) {
            Instantiate(Drum, pos[index].transform);
        } else if (r < 18) {
            Instantiate(Violin, pos[index].transform);
        }
    //     switch (randInt) {
    //         case 0:
    //             Instantiate(GoodNote, pos[0].transform);
    //             break;
    //         case 1:
    //             Instantiate(GoodNote, pos[1].transform);
    //             break;
    //         case 2:
    //             Instantiate(GoodNote, pos[2].transform);
    //             break;
    //         case 3:
    //             Instantiate(GoodNote, pos[3].transform);
    //             break;
    //         case 4:
    //             Instantiate(GoodNote, pos[4].transform);
    //             break;
    //         case 5:
    //             Instantiate(BadNote, pos[0].transform);
    //             break;
    //         case 6:
    //             Instantiate(BadNote, pos[2].transform);
    //             break;
    //         case 7:
    //             Instantiate(BadNote, pos[4].transform);
    //             break;
    //         case 8:
    //             Instantiate(Note, pos[1].transform);
    //             break;
    //         case 9:
    //             Instantiate(Note, pos[3].transform);
    //             break;
    //         default:
    //             break;
    //     }
    } 
}
