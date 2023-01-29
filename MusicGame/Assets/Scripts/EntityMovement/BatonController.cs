using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityStandardAssets.CrossPlatformInput;

public class BatonController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject GameHandler;
    public Vector3 shootDirection;
    public float bulletSpeed;

    // Start: Called when this Player & Baton are created by the Main script
    void Start()
    {
        
    }

    // Update: Called once per frame
    void Update()
    {
        if (GameHandler.GetComponent<GameHandler>().paused) {
            return;
        }

        // Store the normalized position vector of the mouse in the reference frame of the baton (this), in World Space coordinates
        shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position);
        shootDirection.z = 0.0f;
        shootDirection.Normalize();

        // Rotate the baton
        //print(this.gameObject.transform.rotation);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90f + Mathf.Rad2Deg * Mathf.Atan2(shootDirection.y, shootDirection.x));
        //print(this.gameObject.transform.rotation);
        
        if (Input.GetButtonDown("Fire1")) {
            //print("in here");
            // Create the bullet and set this baton as its parent
            Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity, this.gameObject.transform);
            // spawnedBullet.transform.localScale = 0.6f * Vector3.one;
            // spawnedBullet.GetComponent<Rigidbody2D>().velocity = bulletSpeed * shootDirection;
            // spawnedBullet.transform.SetParent(null);
        }
    }
}
