using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject melee;
    private float waittime;
    private bool wait;
    private bool movePlayer;

    private GameObject[] musicStands;

    // public Vector2 speed = new Vector2(1, 1);
    private Rigidbody2D rb2d;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         rb2d = this.GetComponent<Rigidbody2D> ();
         speed = 8;
         melee.SetActive(false);
         waittime = 0.5f;
         wait = false;
         musicStands = GameObject.FindGameObjectsWithTag("MusicStand");
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer = true;
        //musicStands = GameObject.FindGameObjectsWithTag("MusicStand");

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0 || inputY != 0) {
                anim.SetBool("Walk", true);
        } else {
                anim.SetBool("Walk", false);
        }

        if (inputX > 0){
            Vector3 newScale = transform.localScale;
            newScale.x = 1.0f;
            transform.localScale = newScale;
        }
        else if (inputX < 0){
            Vector3 newScale =transform.localScale;
            newScale.x = -1.0f;
            transform.localScale = newScale;
        }

        Vector3 tempVect = new Vector3(inputX, inputY, 0);
        tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;
        Vector3 potentialNewPosn = rb2d.transform.position + tempVect;

        // If the path is blocked by a music stand, then don't move the player

        for (int i = 0; i < musicStands.Length; i++)
        {
            if ((potentialNewPosn - musicStands[i].transform.position).magnitude < 1)
            {
                movePlayer = false;
            }
        }

        // If the player would be leaving the valid enclosure, then don't move the player

        if ((Mathf.Abs(potentialNewPosn.x) > 8.5f) || (potentialNewPosn.y > 4.0f) || (potentialNewPosn.y < -3.0f))
        {
            movePlayer = false;
        }

        // y: -3.0 to +4.1
        // x: -8.5 to +8.5
       
        if (movePlayer)
        {
            rb2d.MovePosition(rb2d.transform.position + tempVect);
        }

        // rb2d.velocity = new Vector2 (inputX*speed, inputY*speed);

        // Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        // movement *= Time.deltaTime;

        // transform.Translate(movement);

        if (wait) {
            waittime -= Time.deltaTime;
            if (waittime < 0) {
                // melee.SetActive(false);
                waittime = 0.2f;
                wait = false;
            }
        }

        if (Input.GetButtonDown("Fire2") && !wait) {
            // melee.SetActive(true);
            wait = true;
        }
    }

    void FixedUpdate()
    {
    }
}
