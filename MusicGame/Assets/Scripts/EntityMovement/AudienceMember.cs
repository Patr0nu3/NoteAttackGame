using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour{

    //public GameHandler gameHandler;
    // public SpriteRenderer audienceMember;
    // private Color colorDefault;
    // public Color colorGreen;
    // public Color colorRed;
    public LayerMask goodNote;
    public LayerMask badNote;
    public Animator anim;

    private int state;

    // private float shakeCd;

    private bool hitGreen = false;
    private bool hitRed = false;

    void Start()
    {
        // colorDefault = audienceMember.color;
        // Debug.Log("hello?");
        anim = this.GetComponent<Animator>();
        anim.SetInteger("Reaction", 0);
        state = 0;
        // shakeCd = 0f;
    }

    void update() {
        // shakeCd += Time.deltaTime;
        // Debug.Log("shakecd: " + shakeCd);
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("I collided something");

        if (other.gameObject.tag == "Friend") {
            if (state == 20) {
                state = 20;
                updateScore(1);
            } else if (state == 10) {
                state = 20;
                anim.SetInteger("Reaction", 20);
                updateScore(1);
            } else if (state == 0) {
                state = 10;
                anim.SetInteger("Reaction", 10);
                updateScore(1);
            } else if (state == -10) {
                state = 0;
                anim.SetInteger("Reaction", 0);
            }
        }

        if (other.gameObject.tag == "Enemy"){
            if (state == -20) {
                updateScore(-3);
            } else if (state == -10) {
                state = -20;
                anim.SetInteger("Reaction", -20);
                updateScore(-3);
            } else if (state == 0) {
                state = -10;
                anim.SetInteger("Reaction", -10);
                updateScore(-3);
            } else if (state == 10) {
                state = 0;
                anim.SetInteger("Reaction", 0);
                updateScore(-3);
            } else if (state == 20) {
                state = 10;
                anim.SetInteger("Reaction", 10);
                updateScore(-3);
            }
        }
        Destroy(other);
        // Debug.Log("int: " + anim.GetInteger("Reaction"));
        //GoodNoteCheck();
        //BadNoteCheck();

        //if (other.gameObject.LayerMask == goodNote){
        //if (other.LayerMask.Contains(goodNote)){
        //if (hitGreen){
        // if (other.gameObject.tag == "Friend"){
        //     StopCoroutine(HitGreen());
        //     StartCoroutine(HitGreen());
        //     //gameHandler.GetPoint(1);
        //     hitGreen = false;
        // }

        //if (other.gameObject.LayerMask == badNote){
        //if (other.LayerMask.Contains(badNote)) {  
        //if (hitRed){
        // if (other.gameObject.tag == "Enemy"){
        //     StopCoroutine(HitRed());
        //     StartCoroutine(HitRed());
        //     //gameHandler.GetPoint(-1);
        //     hitRed = false;
        // }
    }

    void updateScore(int number) {
        if (PlayerPrefs.GetInt("PlayerScore") >= 0 && number < 0) {
            PlayerPrefs.SetInt("PlayerScore", number + PlayerPrefs.GetInt("PlayerScore"));
            CameraShake.Shake(0.1f, 0.3f);
            // if (shakeCd > 1) {
            //     Debug.Log("shake triggered");
            //     CameraShake.Shake(0.1f, 0.3f);
            //     shakeCd = 0;
            // }
        } else if (number > 0) {
            PlayerPrefs.SetInt("PlayerScore", number + PlayerPrefs.GetInt("PlayerScore"));
        }
    }

    // public void GoodNoteCheck(){
    //     Collider2D goodCheck = Physics2D.OverlapCircle(transform.position, 0.5f, goodNote);
    //       if (goodCheck != null){
    //         hitGreen = true;
    //         Debug.Log("I hit green");
    //       }
    // }

    // public void BadNoteCheck(){
    //     Collider2D badCheck = Physics2D.OverlapCircle(transform.position, 0.5f, badNote);
    //       if (badCheck != null){
    //         hitRed = true;
    //         Debug.Log("I hit red");
    //       }
    // }


    // IEnumerator HitGreen(){
    //     audienceMember.color = new Color (colorGreen.r, colorGreen.g, colorGreen.g, 1f);
    //     yield return new WaitForSeconds(0.8f);
    //     audienceMember.color = new Color (colorDefault.r, colorDefault.g, colorDefault.g, 1f);
    // }


    // IEnumerator HitRed(){
    //     audienceMember.color = new Color (colorRed.r, colorRed.g, colorRed.g, 1f);
    //     yield return new WaitForSeconds(0.8f);
    //     Destroy(gameObject);
    // }


}
