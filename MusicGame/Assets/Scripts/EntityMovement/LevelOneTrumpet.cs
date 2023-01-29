using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneTrumpet : MonoBehaviour
{
    float timeInterval;
    float counter;
    int randInt;
    Rigidbody2D thisRB;
    public GameObject BadNote;
    public GameObject GoodNote;
    public float waitTime; 
    float timePassed;
    float yCoord;
    public float xCoord;
    public GameObject gameHandler;

    void Start()
    {
        timeInterval = Random.Range(1.5f, 1.8f);
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        counter = 0;
        thisRB.rotation = 0f;
        timePassed = 0;
        yCoord = 4;
    }

    void Update()
    {
        if (timePassed > waitTime) // delay for trumpet entrance based off input
        {   
            if (transform.position.y != yCoord || transform.position.x != xCoord) //move to final position
            {
                transform.position = Vector3.MoveTowards(new Vector3(xCoord, yCoord, 0), new Vector3(0,0,0), 0.1f);
            }
            if (counter >= timeInterval)
            {
                //Destroy(Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform), 5.0f);
                randInt = Random.Range(0, 11);
                if (randInt > 3)
                {
                    GameObject spawnedBullet = Instantiate(GoodNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                    spawnedBullet.GetComponent<Rigidbody2D>().velocity = 4.5f * Vector2.down;
                }
                else
                {
                    GameObject spawnedBullet = Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                    spawnedBullet.GetComponent<Rigidbody2D>().velocity = 4.5f * Vector2.down;
                }
                counter -= timeInterval;
            }
            counter += Time.deltaTime;
        }
        else 
        {
            timePassed += Time.deltaTime;
        }

        if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(false);
        }
    }
}
