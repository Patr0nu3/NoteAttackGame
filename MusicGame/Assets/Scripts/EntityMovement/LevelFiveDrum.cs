using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFiveDrum : MonoBehaviour
{
    float timeInterval;
    float endTimeInterval;
    float counter;
    int randInt;
    Rigidbody2D thisRB;
    public GameObject BadNote;
    public GameObject GoodNote;
    public float delay;
    public GameObject gameHandler;

    void Start()
    {
        timeInterval = 5.5f;
        endTimeInterval = 3.5f;
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        counter = 0 - delay;
        thisRB.rotation = 0f;

    }

    void Update()
    {
        if (counter >= timeInterval)
        {
            // Bullet 1
            randInt = Random.Range(0, 11);
            if (randInt > 7)
            {
                GameObject spawnedBullet = Instantiate(GoodNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, -3.5f);
            }
            else
            {
                GameObject spawnedBullet = Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(3.5f, -3.5f);
            }
            // Bullet 2
            randInt = Random.Range(0, 11);
            if (randInt > 7)
            {
                GameObject spawnedBullet = Instantiate(GoodNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, -3.5f);
            }
            else
            {
                GameObject spawnedBullet = Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.5f, -3.5f);
            }
            // Bullet 3
            randInt = Random.Range(0, 11);
            if (randInt > 7)
            {
                GameObject spawnedBullet = Instantiate(GoodNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = 3.5f * Vector2.down;
            }
            else
            {
                GameObject spawnedBullet = Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
                spawnedBullet.GetComponent<Rigidbody2D>().velocity = 3.5f * Vector2.down;
            }
            counter -= timeInterval;

            if (timeInterval > endTimeInterval)
            {
                timeInterval -= 0.25f;
            }
        }
        counter += Time.deltaTime;

        if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(false);
        }
    }
}
