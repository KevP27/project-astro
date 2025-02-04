using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHide : MonoBehaviour
{

    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimetoPause()); 
    }
    public IEnumerator TimetoPause()
    {
        yield return new WaitForSeconds(10f);
        canvas.SetActive(false);
    }
}
