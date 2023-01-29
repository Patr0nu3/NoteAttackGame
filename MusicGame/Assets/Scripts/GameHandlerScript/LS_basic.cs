using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_basic : MonoBehaviour
{
    CanvasGroup ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<CanvasGroup>();
        ui.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.alpha < 1) {
            ui.alpha += Time.deltaTime / 1.5f;
        }
    }
}
