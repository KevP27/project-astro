using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public AudioSource boop;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void BoopSound()
    {
        boop.Play();
    }
}
