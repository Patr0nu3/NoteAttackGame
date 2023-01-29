using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Score;
    public AudioSource source;
    public bool paused;
    public bool gameOver = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        paused = false;
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("PlayerScore", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (paused) {
                Resume();
            } else {
                Pause();
            }
        }
        if (!paused && !source.isPlaying) {
            gameOver = true;
        }

        if (gameOver) {
            if (PlayerPrefs.GetInt("PlayerScore") >= 100) {
                /* please add success scene transition here */
                // SceneManager.LoadScene("your scene name");
            }
        }

        Score.transform.GetChild(0).GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("PlayerScore").ToString() + "%";
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        source.Pause();
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        source.Play();
        paused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void JumpToMain()
    {
        Time.timeScale = 1f;
        paused = false;
        SceneManager.LoadScene("Level Menu");
    }

    public void QuitGame()
    {
        // Debug.Log("Quitting");
        // Application.Quit();
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
        #endif
        
        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.Quit();
        #endif
    }
}
