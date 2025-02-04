using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
    private float delayLoading = 3.5f;

    private float timeElapsed;
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayLoading)
        {
            SceneManager.LoadScene("RiceCandy Intro");
        }
    }
}
