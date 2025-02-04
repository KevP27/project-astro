using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float CooldownTime;
    float cooldownUntilNextPress;
    bool press = false;

    public void Pressed()
    {
        press = true;
        if (press == true && cooldownUntilNextPress < Time.time)
        {
            cooldownUntilNextPress = Time.time + CooldownTime;
            Shoot();
            press = false;
        }
    }
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
