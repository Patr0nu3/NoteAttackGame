using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpetController : MonoBehaviour
{
    float timeInterval;
    float counter;
    int randInt;
    Rigidbody2D thisRB;
    public GameObject BadNote;
    public GameObject GoodNote;
    public GameObject gameHandler;

    void Start()
    {
        timeInterval = Random.Range(0.5f, 0.8f);
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        counter = 0;
        thisRB.rotation = 0f;
    }

    void Update()
    {
        if (counter >= timeInterval)
        {
            //Destroy(Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform), 5.0f);
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
            counter -= timeInterval;
        }
        counter += Time.deltaTime;

        if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(false);
        }
    }
}
