using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene1 : MonoBehaviour
{
    private float delayLoading = 0.5f;

    private float timeElapsed;
    // Update is called once per frame
    void Update()
    {
            SceneManager.LoadScene("Start Menu");
    }
}
