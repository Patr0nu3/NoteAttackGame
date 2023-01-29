using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourViolin : MonoBehaviour
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
    public float speed;
    public float xStart;
    public float xEnd;
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
            transform.Translate (Vector2.right * speed * Time.deltaTime);
            
            if(transform.position.x >= xEnd) {
                transform.position = new Vector3(xStart, transform.position.y, transform.position.z);
            }
            

            if (counter >= timeInterval)
            {   
                if (transform.position.x > -9 && transform.position.x < 9)
                {
                     randInt = Random.Range(0, 11);
                    if (randInt > 7)
                    {
                        GameObject spawnedBullet = Instantiate(GoodNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                        spawnedBullet.GetComponent<Rigidbody2D>().velocity = 4.5f * Vector2.down;
                        spawnedBullet.transform.parent = null;
                    }
                    else
                    {
                        GameObject spawnedBullet = Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                        spawnedBullet.GetComponent<Rigidbody2D>().velocity = 4.5f * Vector2.down;
                        spawnedBullet.transform.parent = null;
                    }
                }
                currBullNum += 1;
                counter -= bulletInterval;
                
                if (currBullNum == bulletNum) {
                    counter -= timeInterval;
                    currBullNum = 0;
                }
            }
            counter += Time.deltaTime;
            if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(false);
        }
        }
}
