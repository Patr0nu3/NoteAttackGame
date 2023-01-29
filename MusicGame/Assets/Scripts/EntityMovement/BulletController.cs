using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // The bulletSpeed variable is settable in the BulletController Script section of the Bullet Prefab
    public float bulletSpeed;
    public Animator anim;

    // Start: Called when this bullet is first created by the BatonController script
    void Start()
    {
        // Resize this bullet relative to its parent baton
        this.gameObject.transform.localScale = new Vector3(2, 2, 2);

        // Fix the velocity vector of this bullet
        this.gameObject.GetComponent<Rigidbody2D>().velocity = bulletSpeed * this.gameObject.transform.parent.GetComponent<BatonController>().shootDirection;

        // Disassociate this bullet from its parent baton so that it won't continue to rotate with it
        this.gameObject.transform.SetParent(null);

        // Destroy this bullet after 4 seconds have passed
        Destroy(this.gameObject, 4.0f);
    }

    // FixedUpdate: For physics
    void FixedUpdate()
    {
     
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.name != "Player(Clone)" && collision.gameObject.name != "ToxicArea(Clone)") {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                anim.speed = 10;
                StartCoroutine(Wait());
         }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
