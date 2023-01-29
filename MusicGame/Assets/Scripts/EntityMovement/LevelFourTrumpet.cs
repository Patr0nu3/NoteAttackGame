using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFourTrumpet : MonoBehaviour
{
    float timeInterval;
    float counter;
    int randInt;
    Rigidbody2D thisRB;
    public GameObject BadNote;
    public GameObject GoodNote;
    public float speed;
    public float xStart;
    public float xEnd;
    public float delay;
    public GameObject gameHandler;


    void Start()
    {
        timeInterval = 1.0f;
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        counter = -1 * delay;
        thisRB.rotation = 0f;
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
            //Destroy(Instantiate(BadNote, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform), 5.0f);
            counter -= timeInterval;
        }
        counter += Time.deltaTime;

        if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(false);
        }
    }
}
