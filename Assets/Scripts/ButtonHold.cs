using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHold : MonoBehaviour
{
    public GameObject button; //Drag your breaklight here

    public void onPress()
    {
        button.SetActive(true);
    }

    public void onRelease()
    {
        button.SetActive(false);
    }
}