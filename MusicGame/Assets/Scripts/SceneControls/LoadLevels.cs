using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public GameObject uiFoler;
    public GameObject muFoler;

    private int counter = 0;
    private int normaler;

    /* ---------------- func of buttons ---------------- */

    void Start() {
        normaler = uiFoler.transform.childCount;
        for (int i = 1; i < normaler; i++) {
            uiFoler.transform.GetChild(i).gameObject.SetActive(false);
        }
        uiFoler.transform.GetChild(0).gameObject.SetActive(true);
        muFoler.transform.GetChild(counter).gameObject.GetComponent<AudioSource>().PlayDelayed(1f);
    }

    public void GoNext() {
        uiFoler.transform.GetChild(counter).gameObject.SetActive(false);
        muFoler.transform.GetChild(counter).gameObject.GetComponent<AudioSource>().Stop();
        counter++;
        if (counter >= normaler) {counter = 0;}
        uiFoler.transform.GetChild(counter).gameObject.SetActive(true);
        muFoler.transform.GetChild(counter).gameObject.GetComponent<AudioSource>().PlayDelayed(0.5f);
    }

    public void GoPrevious() {
        uiFoler.transform.GetChild(counter).gameObject.SetActive(false);
        muFoler.transform.GetChild(counter).gameObject.GetComponent<AudioSource>().Stop();
        counter--;
        if (counter <= -1) {counter = normaler - 1;}
        uiFoler.transform.GetChild(counter).gameObject.SetActive(true);
        muFoler.transform.GetChild(counter).gameObject.GetComponent<AudioSource>().PlayDelayed(0.5f);
    }


    /* ---------------- func to different levels ---------------- */

    public void LoadTestLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void loadGivenLevel(string name)
    {
        SceneManager.LoadScene(name);
    }


}
