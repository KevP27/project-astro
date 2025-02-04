using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Volume : MonoBehaviour
{
    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }

    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
    }
}
