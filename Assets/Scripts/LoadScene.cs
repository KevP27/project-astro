using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private float delayLoading = 6.3f;

    private float timeElapsed;
    // Update is called once per frame
    
    void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "RiceCandy Intro 2.mp4");
        videoPlayer.Play();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayLoading)
        {
            SceneManager.LoadScene("Loading 1");
        }
    }

    public void Clicked()
    {
        if (timeElapsed > 3f)
        {
            SceneManager.LoadScene("Loading 1");
        }
    }
}
