using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViolinController : MonoBehaviour
{
    float timeInterval;
    float counter;
    int randInt;
    int bulletNum;
    int currBullNum;
    float bulletInterval;
    Rigidbody2D thisRB;
    public GameObject BadNote;
    public GameObject GoodNote;
    public float delay;
    float yCoord;
    public float xCoord;
    public GameObject gameHandler;

    void Start()
    {
        timeInterval = 3.0f;
        bulletInterval = 0.35f;
        bulletNum = 3;
        currBullNum = 0;
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        counter = 0 - delay;
        thisRB.rotation = 0f;
        yCoord = 4;
    }

    void Update()
    {
         if (counter > 0) // delay for trumpet entrance based off input
        {   
            if (transform.position.y != yCoord || transform.position.x != xCoord) //move to final position
            {
                transform.position = Vector3.MoveTowards(new Vector3(xCoord, yCoord, 0), new Vector3(0,0,0), 0.1f);
            }
            if (counter >= timeInterval)
            {   
                randInt = Random.Range(0, 11);
                if (randInt > 7)
                {
                    GameObject spawnedBullet = Instantiate(GoodNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                    spawnedBullet.GetComponent<Rigidbody2D>().velocity = 4.5f * Vector2.down;
                }
                else
                {
                    GameObject spawnedBullet = Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                    spawnedBullet.GetComponent<Rigidbody2D>().velocity = 4.5f * Vector2.down;
                }
                currBullNum += 1;
                counter -= bulletInterval;
                
                if (currBullNum == bulletNum) {
                    counter -= timeInterval;
                    currBullNum = 0;
                }
            }
        }
        counter += Time.deltaTime;

        if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(false);
        }
    }
}
