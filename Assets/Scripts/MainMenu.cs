using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource boop;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene("Loading");
    }

    public void CharcterSelect()
    {
        SceneManager.LoadScene("Loading");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("Loading 1");
    }

    public void BoopSound()
    {
        boop.Play();
    }
}
