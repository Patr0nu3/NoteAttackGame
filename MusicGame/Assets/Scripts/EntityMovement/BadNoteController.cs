using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadNoteController : MonoBehaviour
{
    Rigidbody2D thisRB;

    void Start()
    {
        thisRB = this.gameObject.GetComponent<Rigidbody2D>();
        // Reduce this bad note's size
        this.gameObject.transform.localScale *= 0.3f;
    }

    void Update()
    {
        if (thisRB.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Trumpet(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
    */

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bad: I collided something");
        //if ((collision.gameObject.name == "Player(Clone)") || (collision.gameObject.name == "end"))
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            PlayerPrefs.SetInt("PlayerScore", 1 + PlayerPrefs.GetInt("PlayerScore"));
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    /*
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().AddForce(-this.GetComponent<Rigidbody2D>().position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            this.GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("PlayerScore", -1 + PlayerPrefs.GetInt("PlayerScore"));
        }       
    }
    */
}
