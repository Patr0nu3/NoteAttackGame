using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_text : MonoBehaviour
{
    public GameObject gameHandler;

    void Start()
    {
        this.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler.GetComponent<GameHandler>().gameOver) {
            this.gameObject.SetActive(true);
        }
    }
}
