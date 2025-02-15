using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;


public class Level1System : MonoBehaviour
{
    [SerializeField] private GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        varGameObject.GetComponent<Laser>().enabled = false;
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
 
    }


}
