using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public GameObject gameHandler;
    public Slider volume;
    public AudioMixer audio;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume")) {
            volume.value = 0.5f;
        } else {
            volume.value = PlayerPrefs.GetFloat("Volume");
        }
        audio.SetFloat("GameVolume", Mathf.Log10(volume.value) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler.GetComponent<GameHandler>().paused) {
            audio.SetFloat("GameVolume", Mathf.Log10(volume.value) * 20);
            PlayerPrefs.SetFloat("Volume", volume.value);
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}

//https://www.chosic.com/download-audio/28004/ test sound source
