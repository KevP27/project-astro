using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene("Loading 2");
    }
}
