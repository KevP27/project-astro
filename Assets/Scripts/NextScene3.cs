using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene3 : MonoBehaviour
{
    private float delayLoading = 0.5f;

    private float timeElapsed;
    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayLoading)
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
