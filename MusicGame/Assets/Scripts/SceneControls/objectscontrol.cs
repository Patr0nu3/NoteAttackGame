using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectscontrol : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "end") {
            Destroy(this.gameObject);
        }
    }
}
