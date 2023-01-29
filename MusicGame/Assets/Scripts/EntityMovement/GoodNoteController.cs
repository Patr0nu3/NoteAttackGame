using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodNoteController : MonoBehaviour
{
    Rigidbody2D thisRB;

    void Start()
    {
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        // Reduce this good note's size
        this.gameObject.transform.localScale *= 0.6f;
    }

    void Update()
    {
        if (thisRB.position.y < -5f)
        {
            // PlayerPrefs.SetInt("PlayerScore", 1 + PlayerPrefs.GetInt("PlayerScore"));
            Destroy(this.gameObject);
        }
    }

    //void Update()
    //{
    //var step = speed * Time.deltaTime;
    //transform.position = Vector3.MoveTowards(transform.position,player.transform.position,step); 
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("good: I collided something");
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            PlayerPrefs.SetInt("PlayerScore", -3 + PlayerPrefs.GetInt("PlayerScore"));
            Destroy(this.gameObject);
        }
        // if (collision.gameObject.name == "Player(Clone)") {
        //     Destroy(this.gameObject);
        //     PlayerPrefs.SetInt("PlayerScore", 1 + PlayerPrefs.GetInt("PlayerScore"));
        /*
        if (collision.gameObject.name == "end") {
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("PlayerScore", 1 + PlayerPrefs.GetInt("PlayerScore"));
        } else if (collision.gameObject.name == "Bullet(Clone)") {
            Destroy(this.gameObject);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
