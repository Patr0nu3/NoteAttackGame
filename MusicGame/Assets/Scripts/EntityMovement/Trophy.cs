using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public GameObject gameHandler;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameHandler.GetComponent<GameHandler>().JumpToMain();
    }
}
