using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBeginning : MonoBehaviour
{
    public GameObject jump;
    public GameObject shoot;
    public GameObject healthBar;
    public GameObject joystick;
    public GameObject pause;



    // Start is called before the first frame update
    void Start()
    {
        jump.SetActive(false);
        shoot.SetActive(false);
        healthBar.SetActive(false);
        joystick.SetActive(false);
        pause.SetActive(false);
    }
}
